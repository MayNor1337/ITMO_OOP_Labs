using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.BaseCommands.СonnectCommands;

public interface IConnectBuilder : IBuilder
{
    IConnectBuilder SetAddress(string address);

    IConnectBuilder SetMode(string mode);
}