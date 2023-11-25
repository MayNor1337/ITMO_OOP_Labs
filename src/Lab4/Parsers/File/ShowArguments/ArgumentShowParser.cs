using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.ShowCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.File.ShowArguments;

public abstract class ArgumentShowParser : IShowArgumentParser
{
    protected IShowArgumentParser? Next { get; set; }

    public IShowArgumentParser AddNext(IShowArgumentParser command)
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

    public abstract ResultParsingArgument Handle(StringIterator command, IShowBuilder builder);
}