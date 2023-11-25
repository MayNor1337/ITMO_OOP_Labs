namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.File;

public class FileParser : ChainCommandBase
{
    private ICommandParser _semiChain;

    public FileParser(ICommandParser semiChain)
    {
        _semiChain = semiChain;
    }

    public override ResultParsingCommand Handle(StringIterator command)
    {
        if (command.GetCurrentString() != "file")
            return Next.Handle(command);

        return _semiChain.Handle(command.Next());
    }
}