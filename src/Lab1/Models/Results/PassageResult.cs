namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

public abstract record PassageResult
{
    private PassageResult() { }

    public sealed record Success : PassageResult;

    public sealed record ImpossibleOvercome : PassageResult;

    public sealed record CrewDied : PassageResult;

    public sealed record ShipDestroyed : PassageResult;
}