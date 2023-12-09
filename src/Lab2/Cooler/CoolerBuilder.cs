using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cooler;

public class CoolerBuilder : ICoolerBuilder
{
    private double? _height;
    private string[]? _supportedSocets;
    private int? _maxTDP;

    public ICoolerBuilder SetHeight(double height)
    {
        _height = height;
        return this;
    }

    public ICoolerBuilder SetSupportedSocets(IEnumerable<string> supportedSocets)
    {
        _supportedSocets = supportedSocets.ToArray();
        return this;
    }

    public ICoolerBuilder SetMaxTDP(int maxTDP)
    {
        _maxTDP = maxTDP;
        return this;
    }

    public ICooler Build()
    {
        return new Cooler(
            _height ?? throw new ArgumentNullException(nameof(_height)),
            _supportedSocets ?? throw new ArgumentNullException(nameof(_height)),
            _maxTDP ?? throw new ArgumentNullException(nameof(_height)));
    }
}