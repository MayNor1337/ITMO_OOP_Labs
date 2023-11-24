using System;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.Factory;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class App
{
    public static void Main()
    {
        var localContext = new Context();
        ICommandParser parser = new ParserFactory().CreateParser();
        while (true)
        {
            string? enteredString = Console.ReadLine();

            if (enteredString is null)
                continue;

            ResultParsingCommand result = parser.Handle(new StringIterator(enteredString));

            if (result is ResultParsingCommand.CommandReceived resultWithCommand)
                resultWithCommand.Command.Execute(localContext);
        }
    }
}