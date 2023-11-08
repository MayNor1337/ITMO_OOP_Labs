using Itmo.ObjectOrientedProgramming.Lab3.Outputters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MockOutputter : IOutputter
{
    public int AmountCalls { get; private set; }

    public void Output(string outputArguments)
    {
        AmountCalls++;
    }
}