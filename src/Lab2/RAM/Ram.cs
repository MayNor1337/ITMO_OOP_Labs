using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.RAM.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.RAM;

public class Ram : IRam
{
    internal Ram(
        int amountMemory,
        IEnumerable<int> frequenciesJedec,
        IXmp xmp,
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
    public IXmp Xmp { get; }
    public string FormFactor { get; }
    public string DdrVersion { get; }
    public int PowerConsumption { get; }

    public IRamBuilder Debuild()
    {
        return new RamBuilder().SetAmountMemory(AmountMemory)
            .SetFrequenciesJEDEC(FrequenciesJEDEC)
            .SetXMP(Xmp)
            .SetFormFactor(FormFactor)
            .SetDDRVersion(DdrVersion)
            .SetPoweConsumptionr(PowerConsumption);
    }
}