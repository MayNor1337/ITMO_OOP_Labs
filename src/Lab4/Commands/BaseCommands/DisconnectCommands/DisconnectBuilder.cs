using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.BaseCommands.DisconnectCommands;

public class DisconnectBuilder : IBuilder
{
    public CommandBuildResult Build()
    {
        return new CommandBuildResult.Successfully(new DisconnectCommand());
    }
}