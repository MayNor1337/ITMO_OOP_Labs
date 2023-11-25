using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands;

public class ListCommand : ICommand
{
    private int _depth;
    private IPrinter _printer;

    public ListCommand(IPrinter printer, int depth = 1)
    {
        _depth = depth;
        _printer = printer;
    }

    public ResultExecuteCommand Execute(Context context)
    {
        if (context.FileSystem is null)
            return new ResultExecuteCommand.CommandExecutionError(ErrorDescriptions.NoConnection());

        string path = context.NowAddress;

        var nowDirectory =
            new DirectoryComponent(
                GetLocalFiles(
                    context, context.FileSystem.MergePaths(path, context.FileSystem.GetDirectoryName(path)), 0),
                context.FileSystem.GetDirectoryName(path),
                0);

        var directoryVisitor = new ListVisitor(_printer);
        nowDirectory.Accept(directoryVisitor);

        return new ResultExecuteCommand.CommandWasExecutedCorrectly();
    }

    private IEnumerable<IVisitorComponent> GetLocalFiles(Context context, string path, int depth)
    {
        if (depth > _depth || context.FileSystem is null)
            return System.Array.Empty<IVisitorComponent>();

        var visitorComponents = new List<IVisitorComponent>();

        string[] directories = context.FileSystem.GetFiles(context.NowAddress);
        string[] files = context.FileSystem.GetFiles(context.NowAddress);

        foreach (string name in directories)
        {
            visitorComponents.Add(
                new DirectoryComponent(
                    GetLocalFiles(context, context.FileSystem.MergePaths(path, name), depth + 1),
                    name,
                    depth + 1));
        }

        foreach (string name in files)
        {
            visitorComponents.Add(
                new FileComponent(name, depth + 1));
        }

        return visitorComponents;
    }
}