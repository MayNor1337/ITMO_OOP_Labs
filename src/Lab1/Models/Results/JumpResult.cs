namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

public record JumpResult
{
    private JumpResult() { }

    public sealed record Success(GravitonMatter GravitonMatter) : JumpResult;

    public sealed record Fail : JumpResult;
}