using System.Globalization;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class StringIterator
{
    private StringBuilder _stringBuilder;
    private int _counter;

    public StringIterator(string startString)
    {
        _stringBuilder = new StringBuilder(startString.ToLower(new CultureInfo("en-US", false)));
    }

    public string GetCurrentString()
    {
        var returnString = new StringBuilder();
        int counter = _counter;

        while (counter < _stringBuilder.Length && _stringBuilder[counter] != ' ')
        {
            returnString.Append(_stringBuilder[counter]);
            counter++;
        }

        return returnString.ToString();
    }

    public StringIterator Next()
    {
        while (_counter < _stringBuilder.Length && _stringBuilder[_counter] != ' ')
            _counter++;

        _counter++;
        return this;
    }

    public bool IsStringFinished()
    {
        return _counter >= _stringBuilder.Length;
    }
}