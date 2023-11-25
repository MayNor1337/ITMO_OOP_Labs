using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands;

public class GoToCommand : ICommand
{
    private string _path;

    public GoToCommand(string path)
    {
        _path = path;
    }

    public ResultExecution Execute(Context context)
    {
        if (context.FileSystem is null)
            return new ResultExecution.NotConnectedToSystem();

        string path = context.FileSystem.MergePaths(context.NowAddress, _path);
        if (context.FileSystem.ExistsDirectory(path) == false)
            return new ResultExecution.DirectoryDoesNotExist();

        context.NowAddress = path;

        return new ResultExecution.Successes();
    }
}