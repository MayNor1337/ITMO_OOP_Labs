using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.CPU;

public interface ICpuBuilder
{
    ICpuBuilder SetClockFrequency(double clockFrequency);

    ICpuBuilder SetNumberCores(int numberCores);

    ICpuBuilder SetSocket(string socket);

    ICpuBuilder AddGraphCore();

    ICpuBuilder AddSupportedMemoryFrequencies(IEnumerable<int> supportedMemoryFrequencies);

    ICpuBuilder SetTDP(int tdp);
    ICpuBuilder SetPowerConsumption(int powerConsumption);

    ICpu Build();
}