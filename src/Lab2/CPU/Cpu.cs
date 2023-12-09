using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.CPU;

public class Cpu : ICpu
{
    internal Cpu(
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

    public ICpuBuilder Debuild()
    {
        return new CpuBuilder().SetName(Name)
            .SetClockFrequency(ClockFrequency)
            .SetNumberCores(NumberCores)
            .SetSocket(Socket)
            .AddSupportedMemoryFrequencies(SupportedMemoryFrequencies)
            .SetTDP(Tdp)
            .SetPowerConsumption(PowerConsumption);
    }
}