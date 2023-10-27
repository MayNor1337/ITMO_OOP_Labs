using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Cooler;
using Itmo.ObjectOrientedProgramming.Lab2.Corpus;
using Itmo.ObjectOrientedProgramming.Lab2.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Drives;
using Itmo.ObjectOrientedProgramming.Lab2.GPU;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.WiFi;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC;

public class PersonalComputer
{
    private IMotherboard _motherboard;
    private ICPU _cpu;
    private ICooler _cooler;
    private IRAM _ram;
    private IGPU? _gpu;
    private List<IDrive> _drives;
    private ICorpus _corpus;
    private IPowerSupply _powerSupply;
    private IWiFi? _wiFi;

    internal PersonalComputer(
        IMotherboard motherboard,
        ICPU cpu,
        ICooler cooler,
        IRAM ram,
        IGPU? gpu,
        IEnumerable<IDrive> drives,
        ICorpus corpus,
        IPowerSupply powerSupply,
        IWiFi? wiFi)
    {
        _motherboard = motherboard;
        _cpu = cpu;
        _cooler = cooler;
        _ram = ram;
        _gpu = gpu;
        _drives = drives.ToList();
        _corpus = corpus;
        _powerSupply = powerSupply;
        _wiFi = wiFi;
    }
}