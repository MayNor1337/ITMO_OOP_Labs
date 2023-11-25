using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.ShowCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.File.ShowArguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.File;

public class ShowParser : ChainCommandBase
{
    private IShowArgumentParser _argumentParser;
    private IPrinter _printer;

    public ShowParser(IShowArgumentParser argumentParser, IPrinter printer)
    {
        _argumentParser = argumentParser;
        _printer = printer;
    }

    public override ResultParsingCommand Handle(StringIterator command)
    {
        if (command.GetCurrentString() != "show")
            return Next.Handle(command);

        string path = command.Next().GetCurrentString();
        if (path is "")
            return new ResultParsingCommand.UnknownCommand();

        var builder = new ShowBuilder(path, _printer);

        command.Next();
        while (command.IsStringFinished() == false)
        {
            ResultParsingArgument parseRes = _argumentParser.Handle(command, builder);
            if (parseRes is ResultParsingArgument.UnknownArgument)
                return new ResultParsingCommand.UnknownCommand();
            command.Next();
        }

        BuildResult result = builder.Build();

        if (result is BuildResult.Successfully successfully)
            return new ResultParsingCommand.CommandReceived(successfully.Command);

        return new ResultParsingCommand.UnknownCommand();
    }
}