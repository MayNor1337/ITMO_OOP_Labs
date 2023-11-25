using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
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

            if (result is not ResultParsingCommand.CommandReceived resultWithCommand)
            {
                Console.WriteLine(ErrorDescriptions.UnknownCommand());
                continue;
            }

            ResultExecuteCommand resultExecute = resultWithCommand.Command.Execute(localContext);
            if (resultExecute is ResultExecuteCommand.CommandExecutionError resultError)
            {
                Console.WriteLine(resultError.Description);
                continue;
            }

            Console.WriteLine(ErrorDescriptions.CommandSuccessfully());
        }
    }
}