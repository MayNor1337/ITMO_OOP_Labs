using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.Arguments;

public abstract class BaseChainArgumentParser : IArgumentParser
{
    private IArgumentParser? _next;

    public IEnumerable<string> GoNext(StringIterator command)
    {
        if (_next is null)
            return new List<string>();

        return _next.Handle(command);
    }

    public IArgumentParser AddNext(IArgumentParser command)
    {
        if (_next is null)
        {
            _next = command;
        }
        else
        {
            _next.AddNext(command);
        }

        return this;
    }

    public abstract IEnumerable<string> Handle(StringIterator command);
}