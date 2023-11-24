using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.ShowCommands;

public class ShowBuilder : IShowBuilder
{
    private readonly int _amountOfArguments = 2;
    private string? _errorDescription;
    private string? _path;
    private string? _mode;

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

    public IBuilder TakeArgumentList(IEnumerable<string> arguments)
    {
        string[] argumentList = arguments.ToArray();

        if (argumentList.Length > _amountOfArguments)
        {
            _errorDescription = ErrorDescriptions.ManyArguments();
            return this;
        }

        if (argumentList.Length > 0)
            _path = argumentList[0];

        if (argumentList.Length > 1)
            _mode = argumentList[1];

        return this;
    }

    public BuildResult Build()
    {
        if (_errorDescription is not null)
            return new BuildResult.Fail(_errorDescription);

        if (_path is null or "")
            return new BuildResult.Fail(ErrorDescriptions.ParameterNotSpecified());

        if (_mode is null or "console")
            return new BuildResult.Successfully(new ShowConsoleModeCommand(_path));

        return new BuildResult.Fail(ErrorDescriptions.UnknownFlagValue());
    }
}