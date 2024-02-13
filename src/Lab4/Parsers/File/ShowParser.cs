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

    public override CommandBuildResult Handle(StringIterator command)
    {
        if (command.GetCurrentString() != "show")
            return Next.Handle(command);

        string path = command.Next().GetCurrentString();
        if (path is "")
            return new CommandBuildResult.ParameterNotSpecified();

        var builder = new ShowBuilder(path, _printer);

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