using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

public record PassingPathResult
{
    private PassingPathResult() { }

    public record Success(FuelStorage Fuel, float Time) : PassingPathResult;

    public sealed record ShipLoss : PassingPathResult;

    public sealed record DestructionShip : PassingPathResult;

    public sealed record CrewDeath : PassingPathResult;

    public sealed record Impossible : PassingPathResult;
}