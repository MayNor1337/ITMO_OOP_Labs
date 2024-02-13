using Itmo.ObjectOrientedProgramming.Lab4.Commands.BaseCommands.СonnectCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.BaseCommand.ConnectArguments;

public abstract class ArgumentConnectParser : IConnectArgumentParser
{
    protected IConnectArgumentParser? Next { get; set; }

    public IConnectArgumentParser AddNext(IConnectArgumentParser command)
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

    public abstract ResultParsingArgument Handle(StringIterator command, IConnectBuilder builder);
}