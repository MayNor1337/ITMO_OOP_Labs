namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.RenameCommands;

public interface IRenameBuilder : IBuilder
{
    public IRenameBuilder SetPath(string path);

    public IRenameBuilder SetName(string name);
}