using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class VirtualOutput
{
    public IList<string> Output { get; private set; } = new List<string>();

    public void OutputText(string text)
    {
        Output.Add(text);
    }
}