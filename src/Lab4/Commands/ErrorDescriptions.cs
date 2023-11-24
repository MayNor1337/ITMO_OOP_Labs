namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public record ErrorDescriptions
{
    public static string ManyArguments() => "too many arguments";

    public static string ParameterNotSpecified() => "parameter(s) not specified";

    public static string UnknownFlagValue() => "unknown flag value";
}