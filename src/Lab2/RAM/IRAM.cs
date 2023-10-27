using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.RAM.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.RAM;

public interface IRAM : IConsumeEnergy, IRAMDebuilder, IComponent
{
    int AmountMemory { get; }
    IEnumerable<int> FrequenciesJEDEC { get; }
    IXMP Xmp { get; }
    string FormFactor { get; }
    string DdrVersion { get; }
}