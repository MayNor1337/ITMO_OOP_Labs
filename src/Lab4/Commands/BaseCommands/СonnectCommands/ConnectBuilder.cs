using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.BaseCommands.СonnectCommands;

public class ConnectBuilder : IConnectBuilder
{
    private string _address;
    private string? _mode;

    public ConnectBuilder(string address)
    {
        _address = address;
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
        if (_mode is null or "")
            return new BuildResult.Fail(ErrorDescriptions.ParameterNotSpecified());

        if (_mode is "local")
            return new BuildResult.Successfully(new LocalConnectCommand(_address));

        return new BuildResult.Fail(ErrorDescriptions.UnknownFlagValue());
    }
}