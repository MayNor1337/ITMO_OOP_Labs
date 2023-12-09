using System;
using System.IO;
using System.Text.Json;
using Itmo.ObjectOrientedProgramming.Lab4.Configs;
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

        string configFilePath = Path.Combine("..", "..", "..", "..", "..", "src/Lab4/Configs/AppConfig.json");
        string jsonString = File.ReadAllText(configFilePath);
        ConfigModel?config = JsonSerializer.Deserialize<ConfigModel>(jsonString);

        if (config is null)
        {
            Console.WriteLine("Attention! Incorrect changes have been made to the config file! The default values will be set!");
            config = new ConfigModel();
        }

        ICommandParser parser = new ParserFactory(config).CreateParser();

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