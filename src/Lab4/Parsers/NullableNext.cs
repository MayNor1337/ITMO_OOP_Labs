namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class NullableNext : ICommandParser
{
    public ICommandParser AddNext(ICommandParser command)
    {
        return this;
    }

    public ResultParsingCommand Handle(StringIterator command)
    {
        return new ResultParsingCommand.UnknownCommand();
    }
}