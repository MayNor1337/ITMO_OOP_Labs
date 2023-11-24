using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.BaseCommands.СonnectCommands;

public class ConnectBuilder : IConnectBuilder
{
    private readonly int _amountOfArguments = 2;
    private string? _errorDescription;
    private string? _address;
    private string? _mode;

    public IBuilder TakeArgumentList(IEnumerable<string> arguments)
    {
        string[] argumentList = arguments.ToArray();

        if (argumentList.Length > _amountOfArguments)
        {
            _errorDescription = ErrorDescriptions.ManyArguments();
            return this;
        }

        if (argumentList.Length > 0)
            _address = argumentList[0];

        if (argumentList.Length > 1)
            _mode = argumentList[1];

        return this;
    }

    public IConnectBuilder SetAddress(string address)
    {
        _address = address;
        return this;
    }

    public IConnectBuilder SetMode(string mode)
    {
        _mode = mode;
        return this;
    }

    public BuildResult Build()
    {
        if (_errorDescription is not null)
            return new BuildResult.Fail(_errorDescription);

        if (_address is null or "" || _mode is null or "")
            return new BuildResult.Fail(ErrorDescriptions.ParameterNotSpecified());

        if (_mode is "local")
            return new BuildResult.Successfully(new LocalConnectCommand(_address));

        return new BuildResult.Fail(ErrorDescriptions.UnknownFlagValue());
    }
}