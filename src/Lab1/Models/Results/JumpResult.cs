using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

public record JumpResult
{
    private JumpResult() { }

    public sealed record Success(IFuel Fuel, float Time) : JumpResult;

    public sealed record Fail : JumpResult;
}