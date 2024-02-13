namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.Factory;

public interface IParserFactory
{
    ICommandParser CreateParser();
}