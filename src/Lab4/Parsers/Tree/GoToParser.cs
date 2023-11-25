using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.Tree;

public class GoToParser : ChainCommandBase
{
    public override CommandBuildResult Handle(StringIterator command)
    {
        if (command.GetCurrentString() != "goto")
            return Next.Handle(command);

        string path = command.Next().GetCurrentString();
        if (path is "")
            return new CommandBuildResult.ParameterNotSpecified();

        return new CommandBuildResult.Successfully(new GoToCommand(path));
    }
}