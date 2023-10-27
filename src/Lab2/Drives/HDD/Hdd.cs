namespace Itmo.ObjectOrientedProgramming.Lab2.Drives.HDD;

public class Hdd : IHdd
{
    internal Hdd(int sizeOfMemory, int spindleRotationSpeed, int powerConsumption)
    {
        SizeOfMemory = sizeOfMemory;
        SpindleRotationSpeed = spindleRotationSpeed;
        PowerConsumption = powerConsumption;
    }

    public int SizeOfMemory { get; }
    public int SpindleRotationSpeed { get; }
    public int PowerConsumption { get; }

    public IHddBuilder Debuild()
    {
        return new HddBuilder().SetSizeOfMemory(SizeOfMemory)
            .SetSpindleRotationSpeed(SpindleRotationSpeed)
            .SetPowerConsumption(PowerConsumption);
    }
}