using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.CPU.Builders;

public class CPUBuilder : CPUBuilderBase
{
    protected override ICPU Create(
        string name,
        double clockFrequency,
        int numberCores,
        bool graphCore,
        string socket,
        IEnumerable<int> supportedMemoryFrequencies,
        int tdp,
        int powerConsumption)
    {
        if (graphCore)
        {
            return new CPUWithGC(
                name,
                clockFrequency,
                numberCores,
                socket,
                supportedMemoryFrequencies,
                tdp,
                powerConsumption);
        }

        return new CPU(name, clockFrequency, numberCores, socket, supportedMemoryFrequencies, tdp, powerConsumption);
    }
}