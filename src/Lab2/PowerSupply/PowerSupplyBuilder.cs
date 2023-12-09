using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

public class PowerSupplyBuilder : IPowerSupplyBuilder
{
    private int? _peakLoad;
    private int _maximumRcommendedLoad;

    public IPowerSupplyBuilder SetPeakLoad(int peakLoad)
    {
        _peakLoad = peakLoad;
        return this;
    }

    public IPowerSupplyBuilder SetMaximumRcommendedLoad(int maximumRcommendedLoad)
    {
        _maximumRcommendedLoad = maximumRcommendedLoad;
        return this;
    }

    public IPowerSupply Build()
    {
        return new PowerSupply(
            _peakLoad ?? throw new ArgumentNullException(nameof(_peakLoad)),
            _maximumRcommendedLoad);
    }
}