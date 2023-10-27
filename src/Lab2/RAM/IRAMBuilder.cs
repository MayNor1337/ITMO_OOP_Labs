using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.RAM.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.RAM;

public interface IRAMBuilder
{
    IRAMBuilder SetAmountMemory(int amountMemory);

    IRAMBuilder SetFrequenciesJEDEC(IEnumerable<int> frequenciesJEDEC);

    IRAMBuilder SetXMP(IXMP xmp);

    IRAMBuilder SetFormFactor(string formFactor);

    IRAMBuilder SetDDRVersion(string ddrVersion);

    IRAMBuilder SetPoweConsumptionr(int powerConsumption);

    IRAM Build();
}