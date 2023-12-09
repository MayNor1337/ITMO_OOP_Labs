using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Drives.HDD;

public interface IHdd : IDrive, IConsumeEnergy, IHddDebuilder, IComponent
{
    int SizeOfMemory { get; }
    int SpindleRotationSpeed { get; }
}