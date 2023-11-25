using Itmo.ObjectOrientedProgramming.Lab4.Commands.BaseCommands.DisconnectCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.BaseCommands.СonnectCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.CopyCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.Delete;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.MoveCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.RenameCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.ShowCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.GoToCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.Arguments;
using Itmo.ObjectOrientedProgramming.Lab4.Printers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.Factory;

public class ParserFactory : IParserFactory
{
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
        return new FinalCommandChain("disconnect", new DisconnectBuilder());
    }

    private static ICommandParser ConnectCommand()
    {
        return new FinalCommandChain("connect", new ConnectBuilder());
    }

    // Tree commands
    private static ICommandParser TreeCommand()
    {
        FinalCommandChain gotoParser = new FinalCommandChain("goto", new GoToBuilder())
            .AddNextArgumentParser(new OneWordParser());

        FinalCommandChain listParser = new FinalCommandChain("list", new ListBuilder(new ConsolePrinter()))
            .AddNextArgumentParser(new FlagParser("-d"));

        return new ClassicParser("tree")
            .AddNextSubquery(gotoParser)
            .AddNextSubquery(listParser);
    }

    // File commands
    private static ICommandParser FileCommand()
    {
        FinalCommandChain showParser = new FinalCommandChain("show", new ShowBuilder())
            .AddNextArgumentParser(new OneWordParser())
            .AddNextArgumentParser(new FlagParser("-m"));

        FinalCommandChain moveParser = new FinalCommandChain("move", new MoveBuilder())
            .AddNextArgumentParser(new OneWordParser())
            .AddNextArgumentParser(new OneWordParser());

        FinalCommandChain copyParser = new FinalCommandChain("copy", new CopyBuilder())
            .AddNextArgumentParser(new OneWordParser())
            .AddNextArgumentParser(new OneWordParser());

        FinalCommandChain deleteParser = new FinalCommandChain("delete", new DeleteBuilder())
            .AddNextArgumentParser(new OneWordParser());

        FinalCommandChain renameParser = new FinalCommandChain("rename", new RenameBuilder())
            .AddNextArgumentParser(new OneWordParser());

        return new ClassicParser("file")
            .AddNextSubquery(showParser)
            .AddNextSubquery(moveParser)
            .AddNextSubquery(copyParser)
            .AddNextSubquery(deleteParser)
            .AddNextSubquery(renameParser);
    }
}