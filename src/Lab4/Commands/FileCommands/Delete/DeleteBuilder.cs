using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.Delete;

public class DeleteBuilder : IDeleteBuilder
{
    private readonly int _amountOfArguments = 1;
    private string? _errorDescription;
    private string? _path;

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

        return this;
    }

    public IDeleteBuilder SetPath(string path)
    {
        _path = path;
        return this;
    }

    public BuildResult Build()
    {
        if (_errorDescription is not null)
            return new BuildResult.Fail(_errorDescription);

        if (_path is null or "")
            return new BuildResult.Fail(ErrorDescriptions.ParameterNotSpecified());

        return new BuildResult.Successfully(new DeleteCommand(_path));
    }
}