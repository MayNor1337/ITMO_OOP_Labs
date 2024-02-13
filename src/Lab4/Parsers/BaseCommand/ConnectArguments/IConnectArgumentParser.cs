using Itmo.ObjectOrientedProgramming.Lab4.Commands.BaseCommands.СonnectCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.BaseCommand.ConnectArguments;

public interface IConnectArgumentParser
{
    public IConnectArgumentParser AddNext(IConnectArgumentParser command);

    public ResultParsingArgument Handle(StringIterator command, IConnectBuilder builder);
}