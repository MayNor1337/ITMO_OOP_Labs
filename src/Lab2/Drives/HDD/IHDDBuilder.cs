namespace Itmo.ObjectOrientedProgramming.Lab2.Drives.HDD;

public interface IHDDBuilder
{
    IHDDBuilder SetSizeOfMemory(int sizeOfMemory);

    IHDDBuilder SetSpindleRotationSpeed(int spindleRotationSpeed);

    IHDDBuilder SetPowerConsumption(int powerConsumption);

    IHDD Build();
}