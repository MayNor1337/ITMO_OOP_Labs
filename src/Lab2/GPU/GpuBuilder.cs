using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.GPU;

public class GpuBuilder : IGpuBuilder
{
    private double? _height;
    private double? _width;
    private int? _videoMemory;
    private string? _versionPCIE;
    private int? _chipFrequency;
    private int? _consumption;

    public IGpuBuilder SetHeight(double height)
    {
        _height = height;
        return this;
    }

    public IGpuBuilder SetWidth(double width)
    {
        _width = width;
        return this;
    }

    public IGpuBuilder SetVideoMemory(int videoMemory)
    {
        _videoMemory = videoMemory;
        return this;
    }

    public IGpuBuilder SetVersionPCIE(string versionPCIE)
    {
        _versionPCIE = versionPCIE;
        return this;
    }

    public IGpuBuilder SetChipFrequency(int chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public IGpuBuilder SetConsumption(int consumption)
    {
        _consumption = consumption;
        return this;
    }

    public IGpu Build()
    {
        return new Gpu(
            _height ?? throw new ArgumentNullException(nameof(_height)),
            _width ?? throw new ArgumentNullException(nameof(_width)),
            _videoMemory ?? throw new ArgumentNullException(nameof(_videoMemory)),
            _versionPCIE ?? throw new ArgumentNullException(nameof(_versionPCIE)),
            _chipFrequency ?? throw new ArgumentNullException(nameof(_chipFrequency)),
            _consumption ?? throw new ArgumentNullException(nameof(_consumption)));
    }
}