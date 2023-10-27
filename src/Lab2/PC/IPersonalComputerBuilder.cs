using System.Collections.Generic;
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

public interface IPersonalComputerBuilder
{
    IPersonalComputerBuilder SetMotherboadr(IMotherboard motherboard);

    IPersonalComputerBuilder SetCPU(ICpu cpu);

    IPersonalComputerBuilder SetCooler(ICooler cooler);

    IPersonalComputerBuilder SetRam(IRam ram);

    IPersonalComputerBuilder SetGPU(IGpu gpu);

    IPersonalComputerBuilder SetDrives(IEnumerable<IDrive> drives);

    IPersonalComputerBuilder SetCorpus(ICorpus corpus);

    IPersonalComputerBuilder SetPowerSupply(IPowerSupply powerSupply);

    IPersonalComputerBuilder SetWiFi(IWiFi wiFi);

    public AssemblingPCResults Build();
}