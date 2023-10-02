namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

public record TakeDamageResult
{
    private TakeDamageResult() { }

    public sealed record Broke : TakeDamageResult;

    public sealed record Normal : TakeDamageResult;
}