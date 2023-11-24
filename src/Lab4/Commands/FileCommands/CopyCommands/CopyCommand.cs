using System.IO;
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

    public void Execute(IContext context)
    {
        string path = context.NowAddress + _sourcePath;
        string destinationPath = context.NowAddress + _destinationPath;

        if (File.Exists(path) == false)
            return;

        File.Copy(path, destinationPath);
    }
}