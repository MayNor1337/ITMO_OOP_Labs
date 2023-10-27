using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.CPU.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.CPU;

public class CPU : ICPU
{
    internal CPU(
        string name,
        double clockFrequency,
        int numberCores,
        string socket,
        IEnumerable<int> supportedMemory,
        int tdp,
        int powerConsumption)
    {
        Name = name;
        ClockFrequency = clockFrequency;
        NumberCores = numberCores;
        Socket = socket;
        SupportedMemoryFrequencies = supportedMemory.ToArray();
        Tdp = tdp;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }
    public double ClockFrequency { get; }
    public int NumberCores { get; }
    public string Socket { get; }
    public IEnumerable<int> SupportedMemoryFrequencies { get; }
    public int Tdp { get; }
    public int PowerConsumption { get; }

    public ICPUBuilder Debuild()
    {
        return new CPUBuilder().SetName(Name)
            .SetClockFrequency(ClockFrequency)
            .SetNumberCores(NumberCores)
            .SetSocket(Socket)
            .AddSupportedMemoryFrequencies(SupportedMemoryFrequencies)
            .SetTDP(Tdp)
            .SetPowerConsumption(PowerConsumption);
    }
}