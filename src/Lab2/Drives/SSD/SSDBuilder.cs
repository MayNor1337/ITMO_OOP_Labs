using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Drives.SSD;

public class SSDBuilder : ISSDBuilder
{
    private ConnectionType? _connectionType;
    private int? _sizeOfMemory;
    private int? _maximumOperatingSpeed;
    private int? _powerConsumption;

    public ISSDBuilder SetConnectionType(ConnectionType connectionType)
    {
        _connectionType = connectionType;
        return this;
    }

    public ISSDBuilder SetSizeOfMemory(int sizeOfMemory)
    {
        _sizeOfMemory = sizeOfMemory;
        return this;
    }

    public ISSDBuilder SetMaximumOperatingSpeed(int maximumOperatingSpeed)
    {
        _maximumOperatingSpeed = maximumOperatingSpeed;
        return this;
    }

    public ISSDBuilder SetPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public ISSD Build()
    {
        return new Drives.SSD.SSD(
            _connectionType ?? throw new ArgumentNullException(nameof(_connectionType)),
            _sizeOfMemory ?? throw new ArgumentNullException(nameof(_sizeOfMemory)),
            _maximumOperatingSpeed ?? throw new ArgumentNullException(nameof(_maximumOperatingSpeed)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}