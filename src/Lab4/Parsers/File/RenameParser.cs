using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.File;

public class RenameParser : ChainCommandBase
{
    public override ResultParsingCommand Handle(StringIterator command)
    {
        if (command.GetCurrentString() != "move")
            return Next.Handle(command);

        string path = command.Next().GetCurrentString();
        string name = command.Next().GetCurrentString();

        if (path is "" || name is "")
            return new ResultParsingCommand.UnknownCommand();

        return new ResultParsingCommand.CommandReceived(new RenameCommand(path, name));
    }
}