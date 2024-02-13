using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.Tree.ListArguments;

public abstract class ArgumentListParser : IListArgumentParser
{
    protected IListArgumentParser? Next { get; set; }

    public IListArgumentParser AddNext(IListArgumentParser command)
    {
        if (Next is null)
        {
            Next = command;
        }
        else
        {
            Next.AddNext(command);
        }

        return this;
    }

    public abstract ResultParsingArgument Handle(StringIterator command, IListBuilder builder);
}