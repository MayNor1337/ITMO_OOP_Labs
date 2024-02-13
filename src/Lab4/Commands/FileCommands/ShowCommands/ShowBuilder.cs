using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.ShowCommands;

public class ShowBuilder : IShowBuilder
{
    private string _path;
    private IPrinter _printer;
    private string? _mode;

    public ShowBuilder(string path, IPrinter printer)
    {
        _path = path;
        _printer = printer;
    }

    public IShowBuilder SetPath(string path)
    {
        _path = path;
        return this;
    }

    public IShowBuilder SetMode(string mode)
    {
        _mode = mode;
        return this;
    }

    public CommandBuildResult Build()
    {
        if (_mode is null or "console")
            return new CommandBuildResult.Successfully(new ShowConsoleModeCommand(_path, _printer));

        return new CommandBuildResult.UnknownFlagValue();
    }
}