namespace Itmo.ObjectOrientedProgramming.Lab2.PC.Validators;

public record ValidationResult
{
    private ValidationResult() { }

    public sealed record Approach : ValidationResult;

    public sealed record Warning(int Amount) : ValidationResult;

    public sealed record NotSuitable : ValidationResult;
}
