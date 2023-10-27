using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.GPU;

public interface IGpu : IConsumeEnergy, IGpuDebulder, IComponent
{
    public double Height { get; }
    public double Width { get; }
    public int VideoMemory { get; }
    public string VersionPCIE { get; }
    public int ChipFrequency { get; }
}