namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public abstract class ChainCommandBase : ICommandParser
{
    protected ICommandParser Next { get; private set; } = new NullableNext();
    protected ICommandParser? NextSubquery { get; private set; }

    public ICommandParser AddNext(ICommandParser command)
    {
        if (Next is NullableNext)
        {
            Next = command;
        }
        else
        {
            Next.AddNext(command);
        }

        return this;
    }

    public ICommandParser AddNextSubquery(ICommandParser command)
    {
        if (Next is NullableNext)
        {
            Next = command;
        }
        else
        {
            Next.AddNext(command);
        }

        return this;
    }

    public abstract CommandBuildResult Handle(StringIterator command);
}