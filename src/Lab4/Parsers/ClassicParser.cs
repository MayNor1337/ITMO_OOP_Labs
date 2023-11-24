namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class ClassicParser : ChainCommandBase
{
    private string _referenceString;

    public ClassicParser(string referenceString)
    {
        _referenceString = referenceString;
    }

    public override ResultParsingCommand Handle(StringIterator command)
    {
        string workString = command.GetCurrentString();

        if (workString == _referenceString && NextSubquery != null)
        {
            return NextSubquery.Handle(command.Next());
        }

        if (workString != _referenceString && Next != null)
            return Next.Handle(command);

        return new ResultParsingCommand.UnknownCommand();
    }
}