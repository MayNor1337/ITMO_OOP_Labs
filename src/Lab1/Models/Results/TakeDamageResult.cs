namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

public record TakeDamageResult
{
    private TakeDamageResult() { }

    public sealed record Broken(float OverDamage) : TakeDamageResult;

    public sealed record Normal : TakeDamageResult;
}