namespace Itmo.ObjectOrientedProgramming.Lab2.GPU;

public class Gpu : IGpu
{
    internal Gpu(
        double height,
        double width,
        int videoMemory,
        string versionPCIE,
        int chipFrequency,
        int consumption)
    {
        Height = height;
        Width = width;
        VideoMemory = videoMemory;
        VersionPCIE = versionPCIE;
        ChipFrequency = chipFrequency;
        PowerConsumption = consumption;
    }

    public double Height { get; }
    public double Width { get; }
    public int VideoMemory { get; }
    public string VersionPCIE { get; }
    public int ChipFrequency { get; }
    public int PowerConsumption { get; }

    public IGpuBuilder Debuild()
    {
        return new GpuBuilder().SetHeight(Height)
            .SetWidth(Width)
            .SetVideoMemory(VideoMemory)
            .SetVersionPCIE(VersionPCIE)
            .SetChipFrequency(ChipFrequency)
            .SetConsumption(PowerConsumption);
    }
}