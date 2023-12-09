using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public class Chipset
{
    private readonly int[] _memoryFrequencies = Array.Empty<int>();
    private readonly bool _xmp;

    public Chipset(IEnumerable<int> memory, bool xmp)
    {
        _memoryFrequencies = memory.ToArray();
        _xmp = xmp;
    }
}