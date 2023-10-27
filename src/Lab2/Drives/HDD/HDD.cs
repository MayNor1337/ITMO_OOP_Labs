namespace Itmo.ObjectOrientedProgramming.Lab2.Drives.HDD;

public class HDD : IHDD
{
    internal HDD(int sizeOfMemory, int spindleRotationSpeed, int powerConsumption)
    {
        SizeOfMemory = sizeOfMemory;
        SpindleRotationSpeed = spindleRotationSpeed;
        PowerConsumption = powerConsumption;
    }

    public int SizeOfMemory { get; }
    public int SpindleRotationSpeed { get; }
    public int PowerConsumption { get; }

    public IHDDBuilder Debuild()
    {
        return new HDDBuilder().SetSizeOfMemory(SizeOfMemory)
            .SetSpindleRotationSpeed(SpindleRotationSpeed)
            .SetPowerConsumption(PowerConsumption);
    }
}