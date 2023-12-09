using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.RAM.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.RAM;

public interface IRamBuilder
{
    IRamBuilder SetAmountMemory(int amountMemory);

    IRamBuilder SetFrequenciesJEDEC(IEnumerable<int> frequenciesJEDEC);

    IRamBuilder SetXMP(IXmp xmp);

    IRamBuilder SetFormFactor(string formFactor);

    IRamBuilder SetDDRVersion(string ddrVersion);

    IRamBuilder SetPoweConsumptionr(int powerConsumption);

    IRam Build();
}