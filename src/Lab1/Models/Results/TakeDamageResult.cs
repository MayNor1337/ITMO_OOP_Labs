namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

public record TakeDamageResult
{
    private TakeDamageResult() { }

    public record Broke : TakeDamageResult;

    public sealed record BrokeAndOverDamage(float OverDamage) : Broke;

    public sealed record Normal : TakeDamageResult;
}