namespace Itmo.ObjectOrientedProgramming.Lab2.Drives.SSD;

public interface ISSDBuilder
{
    ISSDBuilder SetConnectionType(ConnectionType connectionType);

    ISSDBuilder SetSizeOfMemory(int sizeOfMemory);

    ISSDBuilder SetMaximumOperatingSpeed(int maximumOperatingSpeed);

    ISSDBuilder SetPowerConsumption(int powerConsumption);

    ISSD Build();
}