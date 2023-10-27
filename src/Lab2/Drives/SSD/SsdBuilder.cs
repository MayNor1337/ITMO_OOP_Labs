using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Drives.SSD;

public class SsdBuilder : ISsdBuilder
{
    private ConnectionType? _connectionType;
    private int? _sizeOfMemory;
    private int? _maximumOperatingSpeed;
    private int? _powerConsumption;

    public ISsdBuilder SetConnectionType(ConnectionType connectionType)
    {
        _connectionType = connectionType;
        return this;
    }

    public ISsdBuilder SetSizeOfMemory(int sizeOfMemory)
    {
        _sizeOfMemory = sizeOfMemory;
        return this;
    }

    public ISsdBuilder SetMaximumOperatingSpeed(int maximumOperatingSpeed)
    {
        _maximumOperatingSpeed = maximumOperatingSpeed;
        return this;
    }

    public ISsdBuilder SetPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public ISsd Build()
    {
        return new Drives.SSD.Ssd(
            _connectionType ?? throw new ArgumentNullException(nameof(_connectionType)),
            _sizeOfMemory ?? throw new ArgumentNullException(nameof(_sizeOfMemory)),
            _maximumOperatingSpeed ?? throw new ArgumentNullException(nameof(_maximumOperatingSpeed)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}