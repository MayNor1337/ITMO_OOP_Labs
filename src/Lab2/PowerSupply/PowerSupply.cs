namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

public class PowerSupply : IPowerSupply
{
    internal PowerSupply(int peakLoad, int? maximumRcommendedLoad)
    {
        PeakLoad = peakLoad;
        if (maximumRcommendedLoad is null)
        {
            MaximumRcommendedLoad = PeakLoad * 4 / 5;
        }
        else
        {
            MaximumRcommendedLoad = (int)maximumRcommendedLoad;
        }
    }

    public int PeakLoad { get; }
    public int MaximumRcommendedLoad { get; }

    public IPowerSupplyBuilder Debuilder()
    {
        return new PowerSupplyBuilder().SetPeakLoad(PeakLoad)
            .SetMaximumRcommendedLoad(MaximumRcommendedLoad);
    }
}