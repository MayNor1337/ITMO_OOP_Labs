namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.Delete;

public interface IDeleteBuilder : IBuilder
{
    IDeleteBuilder SetPath(string path);
}