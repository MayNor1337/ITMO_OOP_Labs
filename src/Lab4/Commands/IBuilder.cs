using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface IBuilder
{
    CommandBuildResult Build();
}