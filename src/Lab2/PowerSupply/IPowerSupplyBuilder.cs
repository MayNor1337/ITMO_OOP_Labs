namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

public interface IPowerSupplyBuilder
{
    IPowerSupplyBuilder SetPeakLoad(int peakLoad);

    IPowerSupplyBuilder SetMaximumRcommendedLoad(int maximumRcommendedLoad);

    IPowerSupply Build();
}