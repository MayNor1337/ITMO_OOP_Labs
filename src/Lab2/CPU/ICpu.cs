using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.CPU;

public interface ICpu : IConsumeEnergy, ICPUDebuilder, IComponent
{
    public string Name { get; }
    double ClockFrequency { get; }
    int NumberCores { get; }
    string Socket { get; }
    IEnumerable<int> SupportedMemoryFrequencies { get; }
    int Tdp { get; }
}