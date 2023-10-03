namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

public record JumpResult
{
    private JumpResult() { }

    public sealed record Success(ActivePlasma ActivePlasma) : JumpResult;

    public sealed record Fail : JumpResult;
}