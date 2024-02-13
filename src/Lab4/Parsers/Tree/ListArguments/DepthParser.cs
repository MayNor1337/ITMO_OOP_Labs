using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.Tree.ListArguments;

public class DepthParser : ArgumentListParser
{
    public override ResultParsingArgument Handle(StringIterator command, IListBuilder builder)
    {
        if (command.GetCurrentString() != "-d")
        {
            if (Next is null)
                return new ResultParsingArgument.UnknownArgument();
            else
                return Next.Handle(command, builder);
        }

        string depthString = command.Next().GetCurrentString();

        if (int.TryParse(depthString, out int depth))
        {
            builder.SetDepth(depth);
            return new ResultParsingArgument.ReceivedArgument();
        }

        return new ResultParsingArgument.UnknownArgument();
    }
}