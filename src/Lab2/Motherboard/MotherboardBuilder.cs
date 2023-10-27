using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public class MotherboardBuilder : IMotherboardBuilder
{
    private string? _soket;
    private int? _numberPCIELine;
    private int? _numberSATAPorts;
    private Chipset? _chipset;
    private IEnumerable<string>? _standartsDDR;
    private int? _ramSlots;
    private MotherboardFormFactor? _formFactor;
    private BIOS.Bios? _bios;

    public IMotherboardBuilder SetSoket(string soket)
    {
        _soket = soket;
        return this;
    }

    public IMotherboardBuilder SetNumberPCIELine(int numberPCIELine)
    {
        _numberPCIELine = numberPCIELine;
        return this;
    }

    public IMotherboardBuilder SetNumberSATAPorts(int numberSATAPorts)
    {
        _numberSATAPorts = numberSATAPorts;
        return this;
    }

    public IMotherboardBuilder SetChipset(Chipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public IMotherboardBuilder SetStandartsDDR(IEnumerable<string> standartsDDR)
    {
        _standartsDDR = standartsDDR;
        return this;
    }

    public IMotherboardBuilder SetRamSlots(int ramSlots)
    {
        _ramSlots = ramSlots;
        return this;
    }

    public IMotherboardBuilder SetFormFactor(MotherboardFormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IMotherboardBuilder SetBIOS(BIOS.Bios bios)
    {
        _bios = bios;
        return this;
    }

    public IMotherboard Build()
    {
        return new Motherboard(
            _soket ?? throw new ArgumentNullException(nameof(_soket)),
            _numberPCIELine ?? throw new ArgumentNullException(nameof(_numberPCIELine)),
            _numberSATAPorts ?? throw new ArgumentNullException(nameof(_numberSATAPorts)),
            _chipset ?? throw new ArgumentNullException(nameof(_chipset)),
            _standartsDDR ?? throw new ArgumentNullException(nameof(_standartsDDR)),
            _ramSlots ?? throw new ArgumentNullException(nameof(_ramSlots)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _bios ?? throw new ArgumentNullException(nameof(_bios)));
    }
}