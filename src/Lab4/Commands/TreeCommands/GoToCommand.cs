using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands;

public class GoToCommand : ICommand
{
    private string _path;

    public GoToCommand(string path)
    {
        _path = path;
    }

    public ResultExecuteCommand Execute(Context context)
    {
        if (context.FileSystem is null)
            return new ResultExecuteCommand.CommandExecutionError(ErrorDescriptions.NoConnection());

        string path = context.FileSystem.MergePaths(context.NowAddress, _path);

        if (context.FileSystem.ExistsFile(path) == false)
            return new ResultExecuteCommand.CommandExecutionError(ErrorDescriptions.FileDoesNotExist());

        context.NowAddress = path;

        return new ResultExecuteCommand.CommandWasExecutedCorrectly();
    }
}