using Itmo.ObjectOrientedProgramming.Lab4.Commands.BaseCommands.СonnectCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.BaseCommand.ConnectArguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.BaseCommand;

public class ConnectParser : ChainCommandBase
{
    private IConnectArgumentParser _argumentsParser;

    public ConnectParser(IConnectArgumentParser argumentsParser)
    {
        _argumentsParser = argumentsParser;
    }

    public override CommandBuildResult Handle(StringIterator command)
    {
        if (command.GetCurrentString() != "connect")
            return Next.Handle(command);

        string address = command.Next().GetCurrentString();
        if (address is "")
            return new CommandBuildResult.ParameterNotSpecified();

        var builder = new ConnectBuilder(address);

        command.Next();
        while (command.IsStringFinished() == false)
        {
            ResultParsingArgument argumentResult = _argumentsParser.Handle(command, builder);
            if (argumentResult is ResultParsingArgument.UnknownArgument)
                return new CommandBuildResult.UnknownFlagValue();
            command.Next();
        }

        CommandBuildResult result = builder.Build();
        if (result is CommandBuildResult.Successfully success)
            return new CommandBuildResult.Successfully(success.Command);

        return result;
    }
}