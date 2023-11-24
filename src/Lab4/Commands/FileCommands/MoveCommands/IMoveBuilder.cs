namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.MoveCommands;

public interface IMoveBuilder : IBuilder
{
    IMoveBuilder SetSourcePath(string sourcePath);

    IMoveBuilder SetDestinationPath(string destinationPath);
}