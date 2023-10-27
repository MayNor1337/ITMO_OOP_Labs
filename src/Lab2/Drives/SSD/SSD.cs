namespace Itmo.ObjectOrientedProgramming.Lab2.Drives.SSD;

public class SSD : ISSD
{
    public SSD(ConnectionType connectionType, int sizeOfMemory, int maximumOperatingSpeed, int powerConsumption)
    {
        ConnectionType = connectionType;
        SizeOfMemory = sizeOfMemory;
        MaximumOperatingSpeed = maximumOperatingSpeed;
        PowerConsumption = powerConsumption;
    }

    public ConnectionType ConnectionType { get; }
    public int SizeOfMemory { get; }
    public int MaximumOperatingSpeed { get; }
    public int PowerConsumption { get; }

    public ISSDBuilder Debuild()
    {
        return new SSDBuilder().SetConnectionType(ConnectionType)
            .SetSizeOfMemory(SizeOfMemory)
            .SetMaximumOperatingSpeed(MaximumOperatingSpeed)
            .SetPowerConsumption(PowerConsumption);
    }
}