using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Configs;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands;

public class ListCommand : ICommand
{
    private int _depth;
    private IPrinter _printer;
    private ConfigModel _configModel;

    public ListCommand(IPrinter printer, ConfigModel configModel, int? depth)
    {
        if (depth is null)
            _depth = configModel.Depth;
        else
            _depth = (int)depth;

        _printer = printer;
        _configModel = configModel;
    }

    public ResultExecution Execute(Context context)
    {
        if (context.FileSystem is null)
            return new ResultExecution.NotConnectedToSystem();

        string path = context.NowAddress;

        var nowDirectory =
            new DirectoryComponent(
                GetLocalFiles(
                    context, context.FileSystem.MergePaths(path, context.FileSystem.GetDirectoryName(path)), 0),
                context.FileSystem.GetDirectoryName(path),
                0);

        var directoryVisitor = new ListVisitor(_printer, _configModel);
        nowDirectory.Accept(directoryVisitor);

        return new ResultExecution.Successes();
    }

    private IEnumerable<IVisitorComponent> GetLocalFiles(Context context, string path, int depth)
    {
        if (depth > _depth || context.FileSystem is null)
            return System.Array.Empty<IVisitorComponent>();

        var visitorComponents = new List<IVisitorComponent>();

        string[] directories = context.FileSystem.GetDirectories(context.NowAddress);
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