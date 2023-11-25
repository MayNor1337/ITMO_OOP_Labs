using Itmo.ObjectOrientedProgramming.Lab4.Commands.BaseCommands.DisconnectCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class DisconnectParser : ChainCommandBase
{
    public override ResultParsingCommand Handle(StringIterator command)
    {
        if (command.GetCurrentString() != "disconnect")
            return Next.Handle(command);

        return new ResultParsingCommand.CommandReceived(new DisconnectCommand());
    }
}