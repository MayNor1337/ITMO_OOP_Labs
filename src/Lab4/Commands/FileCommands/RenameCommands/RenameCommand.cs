using System.IO;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.RenameCommands;

public class RenameCommand : ICommand
{
    private string _path;
    private string _name;

    public RenameCommand(string path, string name)
    {
        _path = path;
        _name = name;
    }

    public void Execute(IContext context)
    {
        string path = context.NowAddress + _path;
        string destinationPath = BuildPathToNewFile(path);

        File.Move(path, destinationPath);
    }

    private string BuildPathToNewFile(string path)
    {
        var sb = new StringBuilder(path);
        int count = sb.Length - 1;

        while (count != 0 && sb[count] != '/')
            count--;

        return sb.ToString(0, count) + _name;
    }
}