using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

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

    public ResultExecuteCommand Execute(Context context)
    {
        if (context.FileSystem is null)
            return new ResultExecuteCommand.CommandExecutionError(ErrorDescriptions.NoConnection());

        string path = context.FileSystem.MergePaths(context.NowAddress, _path);

        if (context.FileSystem.ExistsFile(path) == false)
            return new ResultExecuteCommand.CommandExecutionError(ErrorDescriptions.FileDoesNotExist());

        string destinationPath = BuildPathToNewFile(path);

        context.FileSystem.Move(path, destinationPath);

        return new ResultExecuteCommand.CommandWasExecutedCorrectly();
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