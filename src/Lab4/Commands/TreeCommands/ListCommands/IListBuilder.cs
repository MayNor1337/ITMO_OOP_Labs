namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands;

public interface IListBuilder : IBuilder
{
    IListBuilder SetDepth(int depth);
}