using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.CopyCommands;

public class CopyBuilder : IBuilder
{
    private readonly int _amountOfArguments = 2;
    private string? _errorDescription;
    private string? _sourcePath;
    private string? _destinationPath;

    public IBuilder TakeArgumentList(IEnumerable<string> arguments)
    {
        string[] argumentList = arguments.ToArray();

        if (argumentList.Length > _amountOfArguments)
        {
            _errorDescription = ErrorDescriptions.ManyArguments();
            return this;
        }

        if (argumentList.Length > 0)
            _sourcePath = argumentList[0];

        if (argumentList.Length > 1)
            _destinationPath = argumentList[1];

        return this;
    }

    public CopyBuilder SetSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public CopyBuilder SetDestinationPath(string destinationPath)
    {
        _destinationPath = destinationPath;
        return this;
    }

    public BuildResult Build()
    {
        if (_errorDescription is not null)
            return new BuildResult.Fail(_errorDescription);

        if (_sourcePath is null or "" || _destinationPath is null or "")
            return new BuildResult.Fail(ErrorDescriptions.ParameterNotSpecified());

        return new BuildResult.Successfully(new CopyCommand(_sourcePath, _destinationPath));
    }
}