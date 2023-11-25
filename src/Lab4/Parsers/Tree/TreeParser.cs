namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.Tree;

public class TreeParser : ChainCommandBase
{
    private ICommandParser _semiChain;

    public TreeParser(ICommandParser semiChain)
    {
        _semiChain = semiChain;
    }

    public override ResultParsingCommand Handle(StringIterator command)
    {
        if (command.GetCurrentString() != "tree")
            return Next.Handle(command);

        return _semiChain.Handle(command.Next());
    }
}