using Itmo.ObjectOrientedProgramming.Lab3.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MockLoggerForCountingCalls : ILogger
{
    public int AmountCalls { get; private set; }

    public void Log(string output)
    {
        AmountCalls++;
    }
}