namespace Itmo.ObjectOrientedProgramming.Lab2.Drives.SSD;

public interface ISsdBuilder
{
    ISsdBuilder SetConnectionType(ConnectionType connectionType);

    ISsdBuilder SetSizeOfMemory(int sizeOfMemory);

    ISsdBuilder SetMaximumOperatingSpeed(int maximumOperatingSpeed);

    ISsdBuilder SetPowerConsumption(int powerConsumption);

    ISsd Build();
}