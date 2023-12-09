using Itmo.ObjectOrientedProgramming.Lab3.Outputters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MockPrinter : IPrinter
{
    private VirtualOutput _outputStream;

    public MockPrinter(VirtualOutput outputStream)
    {
        _outputStream = outputStream;
    }

    public int AmountCalls { get; private set; }

    public void Output(string outputArguments)
    {
        _outputStream.OutputText(outputArguments);
        AmountCalls++;
    }
}