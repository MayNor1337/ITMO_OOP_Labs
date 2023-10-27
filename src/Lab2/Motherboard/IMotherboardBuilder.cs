using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public interface IMotherboardBuilder
{
    IMotherboardBuilder SetSoket(string soket);

    IMotherboardBuilder SetNumberPCIELine(int numberPCIELine);

    IMotherboardBuilder SetNumberSATAPorts(int numberSATAPorts);

    IMotherboardBuilder SetChipset(Chipset chipset);

    IMotherboardBuilder SetStandartsDDR(IEnumerable<string> standartsDDR);

    IMotherboardBuilder SetRamSlots(int ramSlots);

    IMotherboardBuilder SetFormFactor(MotherboardFormFactor formFactor);

    IMotherboardBuilder SetBIOS(BIOS.BIOS bios);

    IMotherboard Build();
}