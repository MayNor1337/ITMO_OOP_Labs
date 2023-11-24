namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public interface ICommandParser
{
    ICommandParser AddNext(ICommandParser command);

    ResultParsingCommand Handle(StringIterator command);

    public ICommandParser AddNextSubquery(ICommandParser command);
}