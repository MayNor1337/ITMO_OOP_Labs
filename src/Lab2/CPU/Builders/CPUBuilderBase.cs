using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.CPU.Builders;

public abstract class CPUBuilderBase : ICPUBuilder
{
    private string? _name;
    private double? _clockFrequency;
    private int? _numberCores;
    private string? _socket;
    private bool _graphCore;
    private int[]? _supportedMemoryFrequencies;
    private int? _tdp;
    private int? _powerConsumption;

    public ICPUBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public ICPUBuilder SetClockFrequency(double clockFrequency)
    {
        _clockFrequency = clockFrequency;
        return this;
    }

    public ICPUBuilder SetNumberCores(int numberCores)
    {
        _numberCores = numberCores;
        return this;
    }

    public ICPUBuilder AddGraphCore()
    {
        _graphCore = true;
        return this;
    }

    public ICPUBuilder SetSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public ICPUBuilder AddSupportedMemoryFrequencies(IEnumerable<int> supportedMemoryFrequencies)
    {
        _supportedMemoryFrequencies = supportedMemoryFrequencies.ToArray();
        return this;
    }

    public ICPUBuilder SetTDP(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ICPUBuilder SetPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public ICPU Build()
    {
        return Create(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _clockFrequency ?? throw new ArgumentNullException(nameof(_clockFrequency)),
            _numberCores ?? throw new ArgumentNullException(nameof(_numberCores)),
            _graphCore,
            _socket ?? throw new ArgumentNullException(nameof(_numberCores)),
            _supportedMemoryFrequencies ?? throw new ArgumentNullException(nameof(_numberCores)),
            _tdp ?? throw new ArgumentNullException(nameof(_numberCores)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_numberCores)));
    }

    protected abstract ICPU Create(
        string name,
        double clockFrequency,
        int numberCores,
        bool graphCore,
        string socket,
        IEnumerable<int> supportedMemoryFrequencies,
        int tdp,
        int powerConsumption);
}