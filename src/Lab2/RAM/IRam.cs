using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.RAM.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.RAM;

public interface IRam : IConsumeEnergy, IRamDebuilder, IComponent
{
    int AmountMemory { get; }
    IEnumerable<int> FrequenciesJEDEC { get; }
    IXmp Xmp { get; }
    string FormFactor { get; }
    string DdrVersion { get; }
}