namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public record ResultParsingArgument
{
    private ResultParsingArgument() { }

    public sealed record ReceivedArgument : ResultParsingArgument;

    public sealed record UnknownArgument : ResultParsingArgument;
}