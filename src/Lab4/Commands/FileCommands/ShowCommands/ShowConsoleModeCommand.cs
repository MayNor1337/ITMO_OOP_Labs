using System;
using System.IO;
using System.Linq;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.ShowCommands;

public class ShowConsoleModeCommand : ICommand
{
    private string _path;
    private IPrinter _printer;
    private string[] _supportedFileTypes = new[] { "txt" };

    public ShowConsoleModeCommand(string path, IPrinter printer)
    {
        _path = path;
        _printer = printer;
    }

    public ResultExecution Execute(Context context)
    {
        string path = context.NowAddress + _path;

        if (context.FileSystem is null)
            return new ResultExecution.NotConnectedToSystem();

        if (_supportedFileTypes.Contains(context.FileSystem.GetFileExtension(path)) == false)
            return new ResultExecution.FileIsNotSupported();

        using var reader = new StreamReader(context.FileSystem.Open(path), Encoding.UTF8);

        string content = reader.ReadToEnd();
        _printer.Print(content);

        return new ResultExecution.Successes();
    }
}