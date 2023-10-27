using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.RAM.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.RAM;

public class RAMBuilder : IRAMBuilder
{
    private int? _amountMemory;
    private int[]? _frequenciesJEDEC;
    private IXMP? _xmp;
    private string? _formFactor;
    private string? _ddrVersion;
    private int? _powerConsumption;

    public IRAMBuilder SetAmountMemory(int amountMemory)
    {
        _amountMemory = amountMemory;
        return this;
    }

    public IRAMBuilder SetFrequenciesJEDEC(IEnumerable<int> frequenciesJEDEC)
    {
        _frequenciesJEDEC = frequenciesJEDEC.ToArray();
        return this;
    }

    public IRAMBuilder SetXMP(IXMP xmp)
    {
        _xmp = xmp;
        return this;
    }

    public IRAMBuilder SetFormFactor(string formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IRAMBuilder SetDDRVersion(string ddrVersion)
    {
        _ddrVersion = ddrVersion;
        return this;
    }

    public IRAMBuilder SetPoweConsumptionr(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IRAM Build()
    {
        return new RAM(
            _amountMemory ?? throw new ArgumentNullException(nameof(_amountMemory)),
            _frequenciesJEDEC ?? throw new ArgumentNullException(nameof(_frequenciesJEDEC)),
            _xmp ?? throw new ArgumentNullException(nameof(_xmp)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _ddrVersion ?? throw new ArgumentNullException(nameof(_ddrVersion)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}