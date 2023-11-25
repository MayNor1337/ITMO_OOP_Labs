using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.Tree;

public class GoToParser : ChainCommandBase
{
    public override ResultParsingCommand Handle(StringIterator command)
    {
        if (command.GetCurrentString() != "goto")
            return Next.Handle(command);

        string path = command.Next().GetCurrentString();
        if (path is "")
            return new ResultParsingCommand.UnknownCommand();

        return new ResultParsingCommand.CommandReceived(new GoToCommand(path));
    }
}