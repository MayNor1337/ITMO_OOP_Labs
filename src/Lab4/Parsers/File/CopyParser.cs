using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.File;

public class CopyParser : ChainCommandBase
{
    public override CommandBuildResult Handle(StringIterator command)
    {
        if (command.GetCurrentString() != "copy")
            return Next.Handle(command);

        string sourcePath = command.Next().GetCurrentString();
        string destinationPath = command.Next().GetCurrentString();

        if (sourcePath is "")
            return new CommandBuildResult.ParameterNotSpecified();

        return new CommandBuildResult.Successfully(new CopyCommand(sourcePath, destinationPath));
    }
}