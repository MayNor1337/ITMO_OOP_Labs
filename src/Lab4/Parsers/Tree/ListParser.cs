using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Configs;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.Tree.ListArguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.Tree;

public class ListParser : ChainCommandBase
{
    private IListArgumentParser _argumentParser;
    private IPrinter _printer;
    private ConfigModel _configModel;

    public ListParser(IListArgumentParser argumentParser, IPrinter printer, ConfigModel configModel)
    {
        _argumentParser = argumentParser;
        _printer = printer;
        _configModel = configModel;
    }

    public override CommandBuildResult Handle(StringIterator command)
    {
        if (command.GetCurrentString() != "list")
            return Next.Handle(command);

        var builder = new ListBuilder(_printer, _configModel);

        command.Next();
        while (command.IsStringFinished() == false)
        {
            ResultParsingArgument parseRes = _argumentParser.Handle(command, builder);
            if (parseRes is ResultParsingArgument.UnknownArgument)
                return new CommandBuildResult.UnknownFlagValue();
            command.Next();
        }

        CommandBuildResult result = builder.Build();
        if (result is CommandBuildResult.Successfully successfully)
            return new CommandBuildResult.Successfully(successfully.Command);

        return result;
    }
}