using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class CopyCommand : ICommand
{
    private string _sourcePath;
    private string _destinationPath;

    public CopyCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public ResultExecuteCommand Execute(Context context)
    {
        if (context.FileSystem is null)
            return new ResultExecuteCommand.CommandExecutionError(ErrorDescriptions.NoConnection());

        string path = context.FileSystem.MergePaths(context.NowAddress, _sourcePath);
        string destinationPath = context.FileSystem.MergePaths(context.NowAddress, _destinationPath);

        if (context.FileSystem.ExistsFile(path) == false)
            return new ResultExecuteCommand.CommandExecutionError(ErrorDescriptions.FileDoesNotExist());

        context.FileSystem.Copy(path, destinationPath);
        return new ResultExecuteCommand.CommandWasExecutedCorrectly();
    }
}