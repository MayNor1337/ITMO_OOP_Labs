namespace Itmo.ObjectOrientedProgramming.Lab2.Drives.HDD;

public interface IHddBuilder
{
    IHddBuilder SetSizeOfMemory(int sizeOfMemory);

    IHddBuilder SetSpindleRotationSpeed(int spindleRotationSpeed);

    IHddBuilder SetPowerConsumption(int powerConsumption);

    IHdd Build();
}