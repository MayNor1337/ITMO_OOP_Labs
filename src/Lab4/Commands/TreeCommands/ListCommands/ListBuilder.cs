using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

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

    public BuildResult Build()
    {
        if (_depth is null)
            return new BuildResult.Successfully(new ListCommand(_printer));

        return new BuildResult.Successfully(new ListCommand(_printer, (int)_depth));
    }
}