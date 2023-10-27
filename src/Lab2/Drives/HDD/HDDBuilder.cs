using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Drives.HDD;

public class HDDBuilder : IHDDBuilder
{
    private int? _sizeOfMemory;
    private int? _spindleRotationSpeed;
    private int? _powerConsumption;

    public IHDDBuilder SetSizeOfMemory(int sizeOfMemory)
    {
        _sizeOfMemory = sizeOfMemory;
        return this;
    }

    public IHDDBuilder SetSpindleRotationSpeed(int spindleRotationSpeed)
    {
        _spindleRotationSpeed = spindleRotationSpeed;
        return this;
    }

    public IHDDBuilder SetPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IHDD Build()
    {
        return new Drives.HDD.HDD(
            _sizeOfMemory ?? throw new ArgumentNullException(nameof(_sizeOfMemory)),
            _spindleRotationSpeed ?? throw new ArgumentNullException(nameof(_spindleRotationSpeed)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}