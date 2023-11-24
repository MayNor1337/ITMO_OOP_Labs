namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.GoToCommands;

public interface IGoToBuilder : IBuilder
{
    IGoToBuilder SetPath(string path);
}