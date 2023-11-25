using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.Tree.ListArguments;

public interface IListArgumentParser
{
    public IListArgumentParser AddNext(IListArgumentParser command);

    public ResultParsingArgument Handle(StringIterator command, IListBuilder builder);
}