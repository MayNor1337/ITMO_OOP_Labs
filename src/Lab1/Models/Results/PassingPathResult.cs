namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

public record PassingPathResult
{
    private PassingPathResult() { }

    public record Success : PassingPathResult;

    public record ShipLoss : PassingPathResult;

    public record DestructionShip : PassingPathResult;

    public record CrewDeath : PassingPathResult;

    public record Impossible : PassingPathResult;
}