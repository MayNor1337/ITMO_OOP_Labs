using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.BaseCommands.DisconnectCommands;

public class DisconnectCommand : ICommand
{
    public ResultExecution Execute(Context context)
    {
        context.NowAddress = string.Empty;
        context.FileSystem = null;
        return new ResultExecution.Successes();
    }
}