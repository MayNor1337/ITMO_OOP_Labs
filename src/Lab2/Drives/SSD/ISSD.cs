using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Drives.SSD;

public interface ISSD : IDrive, IConsumeEnergy, ISSDDebuilder, IComponent
{
    ConnectionType ConnectionType { get; }
    int SizeOfMemory { get; }
    int MaximumOperatingSpeed { get; }
}