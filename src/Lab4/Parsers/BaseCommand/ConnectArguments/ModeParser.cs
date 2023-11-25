using Itmo.ObjectOrientedProgramming.Lab4.Commands.BaseCommands.СonnectCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.BaseCommand.ConnectArguments;

public class ModeParser : ArgumentConnectParser
{
    public override ResultParsingArgument Handle(StringIterator command, IConnectBuilder builder)
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