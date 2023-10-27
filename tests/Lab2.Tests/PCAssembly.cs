using Itmo.ObjectOrientedProgramming.Lab2.Cooler;
using Itmo.ObjectOrientedProgramming.Lab2.Corpus;
using Itmo.ObjectOrientedProgramming.Lab2.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.CPU.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Drives.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.PC;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.RAM.XMP;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class PCAssembly
{
    private static string _soket = "M3205";
    private static int _memoryFrequencies = 1666;
    private static string _cpuName = "topLaba";

    private static ICooler _cooler = new CoolerBuilder().SetHeight(1)
        .SetSupportedSocets(new[] { _soket })
        .SetMaxTDP(1000)
        .Build();

    private static ICooler _coolerBad = new CoolerBuilder().SetHeight(1)
        .SetSupportedSocets(new[] { _soket })
        .SetMaxTDP(0)
        .Build();

    private static ICorpus _corpus = new CorpusBuilder().SetCorpusHeight(100)
        .SetCorpusWidth(100)
        .SetCorpusHeight(100)
        .SetMaxHeightGpu(10)
        .SetMaxWidthGPU(10)
        .SetSupportedFormFactor(new[] { MotherboardFormFactor.MicroATX, MotherboardFormFactor.StandartATX })
        .Build();

    private static ICPU _cpu = new CPUBuilder().SetName(_cpuName)
        .SetSocket(_soket)
        .SetClockFrequency(100)
        .SetPowerConsumption(5)
        .SetNumberCores(3)
        .SetTDP(1)
        .AddSupportedMemoryFrequencies(new[] { _memoryFrequencies })
        .AddGraphCore()
        .Build();

    private static ICPU _cpuWithOtherSoket = new CPUBuilder().SetName(_cpuName)
        .SetSocket("M3200")
        .SetClockFrequency(100)
        .SetPowerConsumption(5)
        .SetNumberCores(3)
        .SetTDP(1)
        .AddSupportedMemoryFrequencies(new[] { _memoryFrequencies })
        .AddGraphCore()
        .Build();

    private static IHDD _hdd = new HDDBuilder().SetSizeOfMemory(10)
        .SetPowerConsumption(1)
        .SetSpindleRotationSpeed(1)
        .Build();

    private static IMotherboard _motherboard = new MotherboardBuilder().SetChipset(new Chipset(new[] { 1 }, true))
        .SetSoket(_soket)
        .SetBIOS(new BIOS("xy", "15.04.03", new[] { _cpuName }))
        .SetFormFactor(MotherboardFormFactor.StandartATX)
        .SetRamSlots(2)
        .SetStandartsDDR(new[] { "DDDR5" })
        .SetNumberPCIELine(1)
        .SetNumberSATAPorts(2)
        .Build();

    private static IPowerSupply _powerSupplyGood = new PowerSupplyBuilder().SetPeakLoad(1000)
        .SetMaximumRcommendedLoad(100)
        .Build();

    private static IPowerSupply _powerSupplyBad = new PowerSupplyBuilder().SetPeakLoad(1000)
        .SetMaximumRcommendedLoad(0)
        .Build();

    private static IRAM _ram = new RAMBuilder().SetFormFactor("hz")
        .SetAmountMemory(1000)
        .SetPoweConsumptionr(3)
        .SetDDRVersion("DDDR5")
        .SetXMP(new XMP(16, 16, 18, 18, 5, 16666))
        .SetFrequenciesJEDEC(new[] { 1666 })
        .Build();

    [Fact]
    public void PersonalComputerBuilderWeAssembleTheComputerFromSuitableParts()
    {
        // Arrange
        AssemblingPCResults result = new PersonalComputerBuilder().SetCooler(_cooler)
            .SetCorpus(_corpus)
            .SetRam(_ram)
            .SetDrives(new[] { _hdd })
            .SetMotherboadr(_motherboard)
            .SetPowerSupply(_powerSupplyGood)
            .SetCPU(_cpu)
            .Build();

        Assert.True(result is AssemblingPCResults.Great);
    }

    [Fact]
    public void PersonalComputerBuilderWithAnWarning()
    {
        // Arrange
        AssemblingPCResults result = new PersonalComputerBuilder().SetCooler(_cooler)
            .SetCorpus(_corpus)
            .SetRam(_ram)
            .SetDrives(new[] { _hdd })
            .SetMotherboadr(_motherboard)
            .SetPowerSupply(_powerSupplyBad)
            .SetCPU(_cpu)
            .Build();

        Assert.True(result is AssemblingPCResults.Warning);
    }

    [Fact]
    public void PersonalComputerBuilderBadCooler()
    {
        AssemblingPCResults result = new PersonalComputerBuilder().SetCooler(_coolerBad)
            .SetCorpus(_corpus)
            .SetRam(_ram)
            .SetDrives(new[] { _hdd })
            .SetMotherboadr(_motherboard)
            .SetPowerSupply(_powerSupplyGood)
            .SetCPU(_cpu)
            .Build();

        Assert.True(result is AssemblingPCResults.Warning);
    }

    [Fact]
    public void PersonalComputerBuilderWithUnsuitableComponents()
    {
        AssemblingPCResults result = new PersonalComputerBuilder().SetCooler(_coolerBad)
            .SetCorpus(_corpus)
            .SetRam(_ram)
            .SetDrives(new[] { _hdd })
            .SetMotherboadr(_motherboard)
            .SetPowerSupply(_powerSupplyGood)
            .SetCPU(_cpuWithOtherSoket)
            .Build();

        Assert.True(result is AssemblingPCResults.UnableToAssemble);
    }
}