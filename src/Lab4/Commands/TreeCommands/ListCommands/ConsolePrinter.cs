using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands;

public class ConsolePrinter : IPrinter
{
    public void Print(string output)
    {
        Console.WriteLine(output);
    }
}