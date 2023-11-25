using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.BaseCommands.СonnectCommands;

public class LocalConnectCommand : ICommand
{
    private string _address;

    public LocalConnectCommand(string address)
    {
        _address = address;
    }

    public void Execute(Context context)
    {
        context.NowAddress = _address;
        context.FileSystem = new LocalFileSystem();
    }
}