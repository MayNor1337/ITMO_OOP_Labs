using System;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.FileSystems;
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

            CommandBuildResult commandBuildResult = parser.Handle(new StringIterator(enteredString));

            if (commandBuildResult is not CommandBuildResult.Successfully resultWithCommand)
            {
                Console.WriteLine(commandBuildResult.Message);
                continue;
            }

            ResultExecution resultExecute = resultWithCommand.Command.Execute(localContext);

            Console.WriteLine(resultExecute.Message);
        }
    }
}