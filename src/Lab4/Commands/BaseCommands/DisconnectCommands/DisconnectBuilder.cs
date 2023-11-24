using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.BaseCommands.DisconnectCommands;

public class DisconnectBuilder : IBuilder
{
    private readonly int _amountOfArguments;
    private string? _errorDescription;

    public DisconnectBuilder()
    {
        _amountOfArguments = 0;
    }

    public IBuilder TakeArgumentList(IEnumerable<string> arguments)
    {
        if (arguments.Count() > _amountOfArguments)
            _errorDescription = ErrorDescriptions.ManyArguments();

        return this;
    }

    public BuildResult Build()
    {
        if (_errorDescription is not null)
            return new BuildResult.Fail(_errorDescription);

        return new BuildResult.Successfully(new DisconnectCommand());
    }
}