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
    internal PersonalComputer(
        IMotherboard motherboard,
        ICpu cpu,
        ICooler cooler,
        IRam ram,
        IGpu? gpu,
        IEnumerable<IDrive> drives,
        ICorpus corpus,
        IPowerSupply powerSupply,
        IWiFi? wiFi)
    {
        Motherboard = motherboard;
        this.Cpu = cpu;
        Cooler = cooler;
        Ram = ram;
        Gpu = gpu;
        Drives = drives.ToList();
        Corpus = corpus;
        PowerSupply = powerSupply;
        WiFi = wiFi;
    }

    public IMotherboard Motherboard { get; }
    public ICpu Cpu { get; }
    public ICooler Cooler { get; }
    public IRam Ram { get; }
    public IGpu? Gpu { get; }
    public IEnumerable<IDrive> Drives { get; }
    public ICorpus Corpus { get; }
    public IPowerSupply PowerSupply { get; }
    public IWiFi? WiFi { get; }
}