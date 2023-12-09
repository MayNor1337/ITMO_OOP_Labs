using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.CPU;

public class CpuBuilder : ICpuBuilder
{
    private string? _name;
    private double? _clockFrequency;
    private int? _numberCores;
    private string? _socket;
    private bool _graphCore;
    private int[]? _supportedMemoryFrequencies;
    private int? _tdp;
    private int? _powerConsumption;

    public ICpuBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public ICpuBuilder SetClockFrequency(double clockFrequency)
    {
        _clockFrequency = clockFrequency;
        return this;
    }

    public ICpuBuilder SetNumberCores(int numberCores)
    {
        _numberCores = numberCores;
        return this;
    }

    public ICpuBuilder AddGraphCore()
    {
        _graphCore = true;
        return this;
    }

    public ICpuBuilder SetSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public ICpuBuilder AddSupportedMemoryFrequencies(IEnumerable<int> supportedMemoryFrequencies)
    {
        _supportedMemoryFrequencies = supportedMemoryFrequencies.ToArray();
        return this;
    }

    public ICpuBuilder SetTDP(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ICpuBuilder SetPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public ICpu Build()
    {
        if (_graphCore)
        {
            return new CPUWithGraphicCore(
                _name ?? throw new ArgumentNullException(nameof(_name)),
                _clockFrequency ?? throw new ArgumentNullException(nameof(_clockFrequency)),
                _numberCores ?? throw new ArgumentNullException(nameof(_numberCores)),
                _socket ?? throw new ArgumentNullException(nameof(_numberCores)),
                _supportedMemoryFrequencies ?? throw new ArgumentNullException(nameof(_numberCores)),
                _tdp ?? throw new ArgumentNullException(nameof(_numberCores)),
                _powerConsumption ?? throw new ArgumentNullException(nameof(_numberCores)));
        }

        return new Cpu(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _clockFrequency ?? throw new ArgumentNullException(nameof(_clockFrequency)),
            _numberCores ?? throw new ArgumentNullException(nameof(_numberCores)),
            _socket ?? throw new ArgumentNullException(nameof(_numberCores)),
            _supportedMemoryFrequencies ?? throw new ArgumentNullException(nameof(_numberCores)),
            _tdp ?? throw new ArgumentNullException(nameof(_numberCores)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_numberCores)));
    }
}