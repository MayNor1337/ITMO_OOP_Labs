using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public class Motherboard : IMotherboard
{
    internal Motherboard(
        string soket,
        int numberPcieLine,
        int numberSataPorts,
        Chipset chipset,
        IEnumerable<string> standartsDdr,
        int ramSlots,
        MotherboardFormFactor formFactor,
        BIOS.Bios bios)
    {
        Soket = soket;
        NumberPCIELine = numberPcieLine;
        NumberSATAPorts = numberSataPorts;
        Chipset = chipset;
        StandartsDDR = standartsDdr;
        RamSlots = ramSlots;
        FormFactor = formFactor;
        Bios = bios;
    }

    public string Soket { get; }
    public int NumberPCIELine { get; }
    public int NumberSATAPorts { get; }
    public Chipset Chipset { get; }
    public IEnumerable<string> StandartsDDR { get; }
    public int RamSlots { get; }
    public MotherboardFormFactor FormFactor { get; }
    public BIOS.Bios Bios { get; }

    public IMotherboardBuilder Debuild()
    {
        return new MotherboardBuilder().SetSoket(Soket)
            .SetNumberPCIELine(NumberPCIELine)
            .SetNumberSATAPorts(NumberSATAPorts)
            .SetChipset(Chipset)
            .SetStandartsDDR(StandartsDDR)
            .SetRamSlots(RamSlots)
            .SetFormFactor(FormFactor)
            .SetBIOS(Bios);
    }
}