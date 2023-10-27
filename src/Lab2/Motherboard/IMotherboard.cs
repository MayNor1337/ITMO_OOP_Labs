using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public interface IMotherboard : IMotherboardDebuilder, IComponent
{
    string Soket { get; }
    int NumberPCIELine { get; }
    int NumberSATAPorts { get; }
    Chipset Chipset { get; }
    IEnumerable<string> StandartsDDR { get; }
    int RamSlots { get; }
    MotherboardFormFactor FormFactor { get; }
    BIOS.BIOS Bios { get; }
}