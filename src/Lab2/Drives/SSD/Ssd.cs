namespace Itmo.ObjectOrientedProgramming.Lab2.Drives.SSD;

public class Ssd : ISsd
{
    public Ssd(ConnectionType connectionType, int sizeOfMemory, int maximumOperatingSpeed, int powerConsumption)
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

    public ISsdBuilder Debuild()
    {
        return new SsdBuilder().SetConnectionType(ConnectionType)
            .SetSizeOfMemory(SizeOfMemory)
            .SetMaximumOperatingSpeed(MaximumOperatingSpeed)
            .SetPowerConsumption(PowerConsumption);
    }
}