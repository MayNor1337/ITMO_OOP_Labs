using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class MoveCommand : ICommand
{
    private string _sourcePath;
    private string _destinationPath;

    public MoveCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public ResultExecuteCommand Execute(Context context)
    {
        if (context.FileSystem is null)
            return new ResultExecuteCommand.CommandExecutionError(ErrorDescriptions.NoConnection());

        string path = context.FileSystem.MergePaths(context.NowAddress, _sourcePath);

        if (context.FileSystem.ExistsFile(path) == false)
            return new ResultExecuteCommand.CommandExecutionError(ErrorDescriptions.FileDoesNotExist());

        string destinationPath = context.FileSystem.MergePaths(context.NowAddress, _destinationPath);

        context.FileSystem.Move(path, destinationPath);

        return new ResultExecuteCommand.CommandWasExecutedCorrectly();
    }
}