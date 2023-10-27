using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.CPU;

public interface ICPUBuilder
{
    ICPUBuilder SetClockFrequency(double clockFrequency);

    ICPUBuilder SetNumberCores(int numberCores);

    ICPUBuilder SetSocket(string socket);

    ICPUBuilder AddGraphCore();

    ICPUBuilder AddSupportedMemoryFrequencies(IEnumerable<int> supportedMemoryFrequencies);

    ICPUBuilder SetTDP(int tdp);
    ICPUBuilder SetPowerConsumption(int powerConsumption);

    ICPU Build();
}