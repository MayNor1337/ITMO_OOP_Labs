using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.BaseCommands.DisconnectCommands;

public class DisconnectBuilder : IBuilder
{
    public BuildResult Build()
    {
        return new BuildResult.Successfully(new DisconnectCommand());
    }
}