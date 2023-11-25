using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.BaseCommands.DisconnectCommands;

public class DisconnectCommand : ICommand
{
    public void Execute(Context context)
    {
        context.NowAddress = string.Empty;
    }
}