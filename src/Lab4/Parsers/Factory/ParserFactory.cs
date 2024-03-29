﻿using Itmo.ObjectOrientedProgramming.Lab4.Configs;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.BaseCommand;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.BaseCommand.ConnectArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.File;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.Tree;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.Tree.ListArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Printers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.Factory;

public class ParserFactory : IParserFactory
{
    private ConfigModel _configModel;

    public ParserFactory(ConfigModel configModel)
    {
        _configModel = configModel;
    }

    public ICommandParser CreateParser()
    {
        return FileCommand()
            .AddNext(TreeCommand())
            .AddNext(ConnectCommand())
            .AddNext(DisconnectCommand());
    }

    // Classic commands
    private static ICommandParser DisconnectCommand()
    {
        return new DisconnectParser();
    }

    private static ICommandParser ConnectCommand()
    {
        var argumentParser = new ModeParser();
        return new ConnectParser(argumentParser);
    }

    // File commands
    private static ICommandParser FileCommand()
    {
        ICommandParser secondWordParser =
            new ShowParser(new File.ShowArguments.ModeParser(), new ConsolePrinter())
                .AddNext(new MoveParser())
                .AddNext(new CopyParser())
                .AddNext(new DeleteParser())
                .AddNext(new RenameParser());

        return new FileParser(secondWordParser);
    }

    // Tree commands
    private ICommandParser TreeCommand()
    {
        ICommandParser secondWordParser =
            new GoToParser()
                .AddNext(new ListParser(new DepthParser(), new ConsolePrinter(), _configModel));

        return new TreeParser(secondWordParser);
    }
}