namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts.FileSystems;

public record ResultExecution(string Message)
{
    private ResultExecution()
        : this(Message: string.Empty)
    { }

    public sealed record FileDoesNotExist() : ResultExecution("The file does not exist");

    public sealed record DirectoryDoesNotExist() : ResultExecution("The directory does not exist");

    public sealed record NotConnectedToSystem() : ResultExecution("There is no connection to the system");

    public sealed record FileIsNotSupported() : ResultExecution("The file format is not supported");

    public sealed record Successes() : ResultExecution("The command was executed successfully");
}