using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.CopyCommands;

public class CopyCommand : ICommand
{
    private string _sourcePath;
    private string _destinationPath;

    public CopyCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public void Execute(Context context)
    {
        string path = context.NowAddress + _sourcePath;
        string destinationPath = context.NowAddress + _destinationPath;

        if (context.FileSystem?.Exists(path) == false)
            return;

        context.FileSystem?.Copy(path, destinationPath);
    }
}