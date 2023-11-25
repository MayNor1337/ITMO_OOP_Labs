using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.ShowCommands;

public interface IShowBuilder : IBuilder
{
    public IShowBuilder SetPath(string path);

    public IShowBuilder SetMode(string mode);
}