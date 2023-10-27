using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Drives.HDD;

public class HddBuilder : IHddBuilder
{
    private int? _sizeOfMemory;
    private int? _spindleRotationSpeed;
    private int? _powerConsumption;

    public IHddBuilder SetSizeOfMemory(int sizeOfMemory)
    {
        _sizeOfMemory = sizeOfMemory;
        return this;
    }

    public IHddBuilder SetSpindleRotationSpeed(int spindleRotationSpeed)
    {
        _spindleRotationSpeed = spindleRotationSpeed;
        return this;
    }

    public IHddBuilder SetPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IHdd Build()
    {
        return new Drives.HDD.Hdd(
            _sizeOfMemory ?? throw new ArgumentNullException(nameof(_sizeOfMemory)),
            _spindleRotationSpeed ?? throw new ArgumentNullException(nameof(_spindleRotationSpeed)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}