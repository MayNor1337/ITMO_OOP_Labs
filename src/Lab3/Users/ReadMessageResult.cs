namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public record ReadMessageResult
{
    private ReadMessageResult() { }

    public sealed record MessageReadSuccessfully : ReadMessageResult;

    public sealed record MessageNotFound : ReadMessageResult;

    public sealed record Wrong : ReadMessageResult;
}