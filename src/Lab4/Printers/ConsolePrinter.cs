using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Printers;

public class ConsolePrinter : IPrinter
{
    public void Print(string output)
    {
        Console.WriteLine(output);
    }
}