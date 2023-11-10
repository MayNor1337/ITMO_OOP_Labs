using Itmo.ObjectOrientedProgramming.Lab3.Outputters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MockPrinter : IPrinter
{
    public int AmountCalls { get; private set; }

    public void Output(string outputArguments)
    {
        AmountCalls++;
    }
}