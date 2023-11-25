namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public record ResultExecuteCommand
{
    private ResultExecuteCommand() { }

    public sealed record CommandWasExecutedCorrectly() : ResultExecuteCommand;

    public sealed record CommandExecutionError(string? Description) : ResultExecuteCommand;
}