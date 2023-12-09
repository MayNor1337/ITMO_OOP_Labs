using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

public abstract record PassageResult
{
    private PassageResult() { }

    public sealed record Success(IFuel Fuel, float Time) : PassageResult;

    public sealed record Impossible : PassageResult;

    public sealed record CrewDied : PassageResult;

    public sealed record ShipDestroyed : PassageResult;
}