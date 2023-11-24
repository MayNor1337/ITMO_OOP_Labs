using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.Arguments;

public class FlagParser : BaseChainArgumentParser
{
    private string _flag;

    public FlagParser(string flag)
    {
        _flag = flag;
    }

    public override IEnumerable<string> Handle(StringIterator command)
    {
        if (command.GetCurrentString() == _flag)
        {
            string currentCommand = command.Next().GetCurrentString();
            var list = GoNext(command.Next()).ToList();

            list.Insert(0, currentCommand);

            return list;
        }

        return GoNext(command.Next());
    }
}