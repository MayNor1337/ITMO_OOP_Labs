namespace Itmo.ObjectOrientedProgramming.Lab2.GPU;

public interface IGPUBuilder
{
    IGPUBuilder SetHeight(double height);

    IGPUBuilder SetWidth(double width);

    IGPUBuilder SetVideoMemory(int videoMemory);

    IGPUBuilder SetVersionPCIE(string versionPCIE);

    IGPUBuilder SetChipFrequency(int chipFrequency);

    IGPUBuilder SetConsumption(int consumption);

    IGPU Build();
}