namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

public record DamageShipResult
{
    private DamageShipResult() { }

    public sealed record Survived : DamageShipResult;

    public sealed record Destroyed : DamageShipResult;
}