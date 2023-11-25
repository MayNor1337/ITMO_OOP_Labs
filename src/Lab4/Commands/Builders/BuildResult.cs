namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public record BuildResult
{
    private BuildResult() { }

    public sealed record Successfully(ICommand Command) : BuildResult;

    public sealed record Fail(string ErrorDescription) : BuildResult;
}