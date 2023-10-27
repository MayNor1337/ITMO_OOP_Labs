using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Drives.HDD;

public interface IHDD : IDrive, IConsumeEnergy, IHDDDebuilder, IComponent
{
    int SizeOfMemory { get; }
    int SpindleRotationSpeed { get; }
}