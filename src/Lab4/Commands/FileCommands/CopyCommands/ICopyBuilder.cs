namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.CopyCommands;

public interface ICopyBuilder : IBuilder
{
    ICopyBuilder SetSourcePath(string sourcePath);

    ICopyBuilder SetDestinationPath(string destinationPath);
}