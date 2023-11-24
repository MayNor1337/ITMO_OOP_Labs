using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.Arguments;

public interface IArgumentParser
{
    IEnumerable<string> GoNext(StringIterator command);

    IArgumentParser AddNext(IArgumentParser command);

    IEnumerable<string> Handle(StringIterator command);
}