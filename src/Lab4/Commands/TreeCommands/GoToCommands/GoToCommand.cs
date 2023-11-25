using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.GoToCommands;

public class GoToCommand : ICommand
{
    private string _path;

    public GoToCommand(string path)
    {
        _path = path;
    }

    public void Execute(Context context)
    {
        string path = context.NowAddress + _path;
        context.NowAddress = path;
    }
}