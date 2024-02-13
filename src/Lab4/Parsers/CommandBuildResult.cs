using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public record CommandBuildResult(string Message)
{
    private CommandBuildResult()
    : this(string.Empty)
    { }

    public sealed record Unknown() : CommandBuildResult;

    public sealed record UnknownFlagValue() : CommandBuildResult("Unknown flag value");

    public sealed record ParameterNotSpecified() : CommandBuildResult("Parameter(s) not specified");

    public sealed record Successfully(ICommand Command) : CommandBuildResult;
}