namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public record FindMessageResult
{
    private FindMessageResult() { }

    public sealed record MessageFoundSuccess(MessageStatus Status) : FindMessageResult;

    public sealed record MessageNotFound : FindMessageResult;
}