using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.GPU;

namespace Itmo.ObjectOrientedProgramming.Lab2.CPU;

public class CPUWithGraphicCore : ICpu, ICpuWithGraphicCore
{
    public CPUWithGraphicCore(string name, double clockFrequency, int numberCores, string socket, IEnumerable<int> supportedMemoryFrequencies, int tdp, int powerConsumption)
    {
        PowerConsumption = powerConsumption;
        Name = name;
        ClockFrequency = clockFrequency;
        NumberCores = numberCores;
        Socket = socket;
        SupportedMemoryFrequencies = supportedMemoryFrequencies;
        Tdp = tdp;
    }

    public string Name { get; }
    public double ClockFrequency { get; }
    public int NumberCores { get; }
    public string Socket { get; }
    public IEnumerable<int> SupportedMemoryFrequencies { get; }
    public int Tdp { get; }
    public int PowerConsumption { get; }

    public ICpuBuilder Debuild()
    {
        return new CpuBuilder().SetName(Name)
            .SetClockFrequency(ClockFrequency)
            .SetNumberCores(NumberCores)
            .SetSocket(Socket)
            .AddSupportedMemoryFrequencies(SupportedMemoryFrequencies)
            .SetTDP(Tdp)
            .SetPowerConsumption(PowerConsumption)
            .AddGraphCore();
    }
}