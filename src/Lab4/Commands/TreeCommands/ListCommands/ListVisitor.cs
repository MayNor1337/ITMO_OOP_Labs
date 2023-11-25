using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Configs;
using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands;

public class ListVisitor : IVisitor
{
    private char _symbolFolder;
    private char _symbolFile;
    private char _symbolIndent;
    private IPrinter _printer;

    public ListVisitor(IPrinter printer, ConfigModel configModel)
    {
        _printer = printer;
        _symbolFolder = configModel.SymbolFolder;
        _symbolFile = configModel.SymbolFile;
        _symbolIndent = configModel.SymbolIndent;
    }

    public void Visit(IVisitorComponent component)
    {
        if (component is DirectoryComponent directoryComponent)
            PrintDirectory(directoryComponent);

        if (component is FileComponent fileComponent)
            PrintFile(fileComponent);
    }

    private void PrintDirectory(DirectoryComponent component)
    {
        _printer.Print(
            string.Concat(Enumerable.Repeat(_symbolIndent, component.Depth))
            + _symbolFolder
            + component.Name);
    }

    private void PrintFile(FileComponent component)
    {
        _printer.Print(
            string.Concat(Enumerable.Repeat(_symbolIndent, component.Depth))
            + _symbolFile
            + component.Name);
    }
}