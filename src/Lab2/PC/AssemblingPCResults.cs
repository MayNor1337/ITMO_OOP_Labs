namespace Itmo.ObjectOrientedProgramming.Lab2.PC;

public record AssemblingPCResults
{
    private AssemblingPCResults() { }

    public sealed record UnableToAssemble : AssemblingPCResults;

    public sealed record Warning(PersonalComputer PersonalComputer) : AssemblingPCResults;

    public sealed record Great(PersonalComputer PersonalComputer) : AssemblingPCResults;
}