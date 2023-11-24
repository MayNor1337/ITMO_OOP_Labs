using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.Arguments;

public class OneWordParser : BaseChainArgumentParser
{
    public override IEnumerable<string> Handle(StringIterator command)
    {
        string nowString = command.GetCurrentString();
        var argumentsList = GoNext(command.Next()).ToList();
        argumentsList.Insert(0, nowString);

        return argumentsList;
    }
}