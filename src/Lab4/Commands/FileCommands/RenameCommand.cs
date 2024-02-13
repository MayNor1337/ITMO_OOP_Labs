using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class RenameCommand : ICommand
{
    private string _path;
    private string _name;

    public RenameCommand(string path, string name)
    {
        _path = path;
        _name = name;
    }

    public ResultExecution Execute(Context context)
    {
        if (context.FileSystem is null)
            return new ResultExecution.NotConnectedToSystem();

        string path = context.FileSystem.MergePaths(context.NowAddress, _path);
        string destinationPath = BuildPathToNewFile(path);

        return context.FileSystem.Move(path, destinationPath);
    }

    private string BuildPathToNewFile(string path)
    {
        var sb = new StringBuilder(path);
        int count = sb.Length - 1;

        while (count != 0 && sb[count] != '\\')
            count--;

        return sb.ToString(0, count) + _name;
    }
}