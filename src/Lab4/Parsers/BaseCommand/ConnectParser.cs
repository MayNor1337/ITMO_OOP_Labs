using Itmo.ObjectOrientedProgramming.Lab4.Commands.BaseCommands.СonnectCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.BaseCommand.ConnectArguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.BaseCommand;

public class ConnectParser : ChainCommandBase
{
    private IConnectArgumentParser _argumentsParser;

    public ConnectParser(IConnectArgumentParser argumentsParser)
    {
        _argumentsParser = argumentsParser;
    }

    public override ResultParsingCommand Handle(StringIterator command)
    {
        if (command.GetCurrentString() != "connect")
            return Next.Handle(command);

        string address = command.Next().GetCurrentString();
        if (address is "")
            return new ResultParsingCommand.UnknownCommand();

        var builder = new ConnectBuilder(address);

        command.Next();
        while (command.IsStringFinished() == false)
        {
            ResultParsingArgument argumentResult = _argumentsParser.Handle(command, builder);
            if (argumentResult is ResultParsingArgument.UnknownArgument)
                return new ResultParsingCommand.UnknownCommand();
            command.Next();
        }

        BuildResult result = builder.Build();
        if (result is BuildResult.Successfully success)
            return new ResultParsingCommand.CommandReceived(success.Command);

        return new ResultParsingCommand.UnknownCommand();
    }
}