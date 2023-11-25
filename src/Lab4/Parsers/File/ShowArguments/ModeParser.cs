using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.ShowCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.File.ShowArguments;

public class ModeParser : ArgumentShowParser
{
    public override ResultParsingArgument Handle(StringIterator command, IShowBuilder builder)
    {
        if (command.GetCurrentString() != "-m")
        {
            if (Next is null)
                return new ResultParsingArgument.UnknownArgument();
            else
                return Next.Handle(command, builder);
        }

        string mode = command.Next().GetCurrentString();

        if (mode is "")
            return new ResultParsingArgument.UnknownArgument();

        builder.SetMode(mode);
        return new ResultParsingArgument.ReceivedArgument();
    }
}