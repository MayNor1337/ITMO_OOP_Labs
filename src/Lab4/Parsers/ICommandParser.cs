namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public interface ICommandParser
{
    ICommandParser AddNext(ICommandParser command);

    CommandBuildResult Handle(StringIterator command);
}