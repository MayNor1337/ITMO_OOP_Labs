using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.File;

public class DeleteParser : ChainCommandBase
{
    public override ResultParsingCommand Handle(StringIterator command)
    {
        if (command.GetCurrentString() != "delete")
            return Next.Handle(command);

        string path = command.Next().GetCurrentString();

        if (path is "")
            return new ResultParsingCommand.UnknownCommand();

        return new ResultParsingCommand.CommandReceived(new DeleteCommand(path));
    }
}