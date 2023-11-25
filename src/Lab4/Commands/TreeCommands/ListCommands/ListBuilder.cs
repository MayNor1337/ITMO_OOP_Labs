using Itmo.ObjectOrientedProgramming.Lab4.Configs;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands;

public class ListBuilder : IListBuilder
{
    private int? _depth;
    private IPrinter _printer;
    private ConfigModel _configModel;

    public ListBuilder(IPrinter printer, ConfigModel configModel)
    {
        _printer = printer;
        _configModel = configModel;
    }

    public IListBuilder SetDepth(int depth)
    {
        _depth = depth;
        return this;
    }

    public CommandBuildResult Build()
    {
        return new CommandBuildResult.Successfully(new ListCommand(_printer, _configModel, (int)_depth));
    }
}