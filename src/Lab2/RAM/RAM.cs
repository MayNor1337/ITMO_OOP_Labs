using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.RAM.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.RAM;

public class RAM : IRAM
{
    internal RAM(
        int amountMemory,
        IEnumerable<int> frequenciesJedec,
        IXMP xmp,
        string formFactor,
        string ddrVersion,
        int powerConsumption)
    {
        AmountMemory = amountMemory;
        FrequenciesJEDEC = frequenciesJedec.ToArray();
        Xmp = xmp;
        FormFactor = formFactor;
        DdrVersion = ddrVersion;
        PowerConsumption = powerConsumption;
    }

    public int AmountMemory { get; }
    public IEnumerable<int> FrequenciesJEDEC { get; }
    public IXMP Xmp { get; }
    public string FormFactor { get; }
    public string DdrVersion { get; }
    public int PowerConsumption { get; }

    public IRAMBuilder Debuild()
    {
        return new RAMBuilder().SetAmountMemory(AmountMemory)
            .SetFrequenciesJEDEC(FrequenciesJEDEC)
            .SetXMP(Xmp)
            .SetFormFactor(FormFactor)
            .SetDDRVersion(DdrVersion)
            .SetPoweConsumptionr(PowerConsumption);
    }
}