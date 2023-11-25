using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands;

public class ListBuilder : IListBuilder
{
    private int? _depth;
    private IPrinter _printer;

    public ListBuilder(IPrinter printer)
    {
        _printer = printer;
    }

    public IListBuilder SetDepth(int depth)
    {
        _depth = depth;
        return this;
    }

    public CommandBuildResult Build()
    {
        if (_depth is null)
            return new CommandBuildResult.Successfully(new ListCommand(_printer));

        return new CommandBuildResult.Successfully(new ListCommand(_printer, (int)_depth));
    }
}