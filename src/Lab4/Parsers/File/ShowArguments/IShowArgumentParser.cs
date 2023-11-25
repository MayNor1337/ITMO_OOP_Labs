using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.ShowCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.File.ShowArguments;

public interface IShowArgumentParser
{
    public IShowArgumentParser AddNext(IShowArgumentParser command);

    public ResultParsingArgument Handle(StringIterator command, IShowBuilder builder);
}