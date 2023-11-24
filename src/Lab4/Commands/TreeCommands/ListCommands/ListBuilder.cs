using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands;

public class ListBuilder : IListBuilder
{
    private readonly int _amountOfArguments = 1;
    private string? _errorDescription;
    private int? _depth;
    private IPrinter _printer;

    public ListBuilder(IPrinter printer)
    {
        _printer = printer;
    }

    public IBuilder TakeArgumentList(IEnumerable<string> arguments)
    {
        string[] argumentList = arguments.ToArray();

        if (argumentList.Length > _amountOfArguments)
        {
            _errorDescription = ErrorDescriptions.ManyArguments();
            return this;
        }

        if (argumentList.Length > 0 && int.TryParse(argumentList[0], out int depth))
            _depth = depth;

        return this;
    }

    public IListBuilder SetDepth(int depth)
    {
        _depth = depth;
        return this;
    }

    public BuildResult Build()
    {
        if (_errorDescription is not null)
            return new BuildResult.Fail(_errorDescription);

        if (_depth is not null)
            return new BuildResult.Successfully(new ListCommand(_printer, (int)_depth));

        return new BuildResult.Successfully(new ListCommand(_printer));
    }
}