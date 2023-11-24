using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public record ResultParsingCommand
{
    private ResultParsingCommand() { }

    public sealed record UnknownCommand() : ResultParsingCommand;

    public sealed record CommandReceived(ICommand Command) : ResultParsingCommand;
}