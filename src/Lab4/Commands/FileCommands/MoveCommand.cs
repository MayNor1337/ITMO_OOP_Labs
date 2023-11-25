using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.FileSystems;

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

    public ResultExecution Execute(Context context)
    {
        if (context.FileSystem is null)
            return new ResultExecution.NotConnectedToSystem();

        string path = context.FileSystem.MergePaths(context.NowAddress, _sourcePath);
        string destinationPath = context.FileSystem.MergePaths(context.NowAddress, _destinationPath);

        return context.FileSystem.Move(path, destinationPath);
    }
}