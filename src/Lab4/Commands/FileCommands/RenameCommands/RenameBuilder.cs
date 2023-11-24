using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.RenameCommands;

public class RenameBuilder : IRenameBuilder
{
    private readonly int _amountOfArguments = 2;
    private string? _errorDescription;
    private string? _path;
    private string? _name;

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
            _name = argumentList[1];

        return this;
    }

    public IRenameBuilder SetPath(string path)
    {
        _path = path;
        return this;
    }

    public IRenameBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public BuildResult Build()
    {
        if (_errorDescription is not null)
            return new BuildResult.Fail(_errorDescription);

        if (_path is null or "" || _name is null or "")
            return new BuildResult.Fail(ErrorDescriptions.ParameterNotSpecified());

        return new BuildResult.Successfully(new RenameCommand(_path, _name));
    }
}