namespace Itmo.ObjectOrientedProgramming.Lab2.GPU;

public interface IGpuBuilder
{
    IGpuBuilder SetHeight(double height);

    IGpuBuilder SetWidth(double width);

    IGpuBuilder SetVideoMemory(int videoMemory);

    IGpuBuilder SetVersionPCIE(string versionPCIE);

    IGpuBuilder SetChipFrequency(int chipFrequency);

    IGpuBuilder SetConsumption(int consumption);

    IGpu Build();
}