using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands;

public class ListCommand : ICommand
{
    private int _depth;
    private IPrinter _printer;

    public ListCommand(IPrinter printer, int depth = 1)
    {
        _depth = depth;
        _printer = printer;
    }

    public void Execute(Context context)
    {
        // TODO: Make for the lesson
        throw new System.NotImplementedException();
    }
}