using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class DeleteCommand : ICommand
{
    private string _path;

    public DeleteCommand(string path)
    {
        _path = path;
    }

    public ResultExecution Execute(Context context)
    {
        if (context.FileSystem is null)
            return new ResultExecution.NotConnectedToSystem();

        string path = context.NowAddress + _path;
        return context.FileSystem.Delete(path);
    }
}