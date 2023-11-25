using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class DeleteCommand : ICommand
{
    private string _path;

    public DeleteCommand(string path)
    {
        _path = path;
    }

    public ResultExecuteCommand Execute(Context context)
    {
        if (context.FileSystem is null)
            return new ResultExecuteCommand.CommandExecutionError(ErrorDescriptions.NoConnection());

        string path = context.NowAddress + _path;

        if (context.FileSystem.ExistsFile(path) == false)
            return new ResultExecuteCommand.CommandExecutionError(ErrorDescriptions.FileDoesNotExist());

        context.FileSystem.Delete(path);

        return new ResultExecuteCommand.CommandWasExecutedCorrectly();
    }
}