using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface IBuilder
{
    IBuilder TakeArgumentList(IEnumerable<string> arguments);

    BuildResult Build();
}