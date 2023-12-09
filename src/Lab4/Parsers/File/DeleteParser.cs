using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.File;

public class DeleteParser : ChainCommandBase
{
    public override CommandBuildResult Handle(StringIterator command)
    {
        if (command.GetCurrentString() != "delete")
            return Next.Handle(command);

        string path = command.Next().GetCurrentString();

        if (path is "")
            return new CommandBuildResult.ParameterNotSpecified();

        return new CommandBuildResult.Successfully(new DeleteCommand(path));
    }
}