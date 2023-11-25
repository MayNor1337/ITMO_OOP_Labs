namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class NullableNext : ICommandParser
{
    public ICommandParser AddNext(ICommandParser command)
    {
        return this;
    }

    public CommandBuildResult Handle(StringIterator command)
    {
        return new CommandBuildResult.ParameterNotSpecified();
    }
}