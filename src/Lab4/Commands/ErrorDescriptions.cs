namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public record ErrorDescriptions
{
    public static string ManyArguments() => "Too many arguments";

    public static string ParameterNotSpecified() => "Parameter(s) not specified";

    public static string UnknownFlagValue() => "Unknown flag value";

    public static string NoConnection() => "There is no connection to the system";

    public static string FileDoesNotExist() => "The file does not exist";

    public static string FileFormatNotSupported() => "The file format is not supported";

    public static string UnknownCommand() => "Unknown command";

    public static string CommandSuccessfully() => "The command was executed successfully";
}