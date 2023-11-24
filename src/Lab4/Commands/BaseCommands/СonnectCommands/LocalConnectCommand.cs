using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.BaseCommands.СonnectCommands;

public class LocalConnectCommand : ICommand
{
    private string _address;

    public LocalConnectCommand(string address)
    {
        _address = address;
    }

    public void Execute(IContext context)
    {
        context.NowAddress = _address;
    }
}