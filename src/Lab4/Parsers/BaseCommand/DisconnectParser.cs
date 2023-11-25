using Itmo.ObjectOrientedProgramming.Lab4.Commands.BaseCommands.DisconnectCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class DisconnectParser : ChainCommandBase
{
    public override CommandBuildResult Handle(StringIterator command)
    {
        if (command.GetCurrentString() != "disconnect")
            return Next.Handle(command);

        return new CommandBuildResult.Successfully(new DisconnectCommand());
    }
}