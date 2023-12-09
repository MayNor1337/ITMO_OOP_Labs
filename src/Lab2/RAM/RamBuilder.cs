using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.RAM.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.RAM;

public class RamBuilder : IRamBuilder
{
    private int? _amountMemory;
    private int[]? _frequenciesJEDEC;
    private IXmp? _xmp;
    private string? _formFactor;
    private string? _ddrVersion;
    private int? _powerConsumption;

    public IRamBuilder SetAmountMemory(int amountMemory)
    {
        _amountMemory = amountMemory;
        return this;
    }

    public IRamBuilder SetFrequenciesJEDEC(IEnumerable<int> frequenciesJEDEC)
    {
        _frequenciesJEDEC = frequenciesJEDEC.ToArray();
        return this;
    }

    public IRamBuilder SetXMP(IXmp xmp)
    {
        _xmp = xmp;
        return this;
    }

    public IRamBuilder SetFormFactor(string formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IRamBuilder SetDDRVersion(string ddrVersion)
    {
        _ddrVersion = ddrVersion;
        return this;
    }

    public IRamBuilder SetPoweConsumptionr(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IRam Build()
    {
        return new Ram(
            _amountMemory ?? throw new ArgumentNullException(nameof(_amountMemory)),
            _frequenciesJEDEC ?? throw new ArgumentNullException(nameof(_frequenciesJEDEC)),
            _xmp ?? throw new ArgumentNullException(nameof(_xmp)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _ddrVersion ?? throw new ArgumentNullException(nameof(_ddrVersion)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}