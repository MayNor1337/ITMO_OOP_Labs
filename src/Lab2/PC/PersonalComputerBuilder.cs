﻿using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Cooler;
using Itmo.ObjectOrientedProgramming.Lab2.Corpus;
using Itmo.ObjectOrientedProgramming.Lab2.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Drives;
using Itmo.ObjectOrientedProgramming.Lab2.GPU;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Validators;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.WiFi;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC;

public class PersonalComputerBuilder : IPersonalComputerBuilder
{
    private IMotherboard? _motherboard;
    private ICpu? _cpu;
    private ICooler? _cooler;
    private IRam? _ram;
    private IGpu? _gpu;
    private List<IDrive>? _drives;
    private ICorpus? _corpus;
    private IPowerSupply? _powerSupply;
    private IWiFi? _wiFi;
    private IValidator _validator;

    public PersonalComputerBuilder(IValidator validator)
    {
        _validator = validator;
    }

    public IPersonalComputerBuilder SetMotherboadr(IMotherboard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public IPersonalComputerBuilder SetCPU(ICpu cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IPersonalComputerBuilder SetCooler(ICooler cooler)
    {
        _cooler = cooler;
        return this;
    }

    public IPersonalComputerBuilder SetRam(IRam ram)
    {
        _ram = ram;
        return this;
    }

    public IPersonalComputerBuilder SetGPU(IGpu gpu)
    {
        _gpu = gpu;
        return this;
    }

    public IPersonalComputerBuilder SetDrives(IEnumerable<IDrive> drives)
    {
        _drives = drives.ToList();
        return this;
    }

    public IPersonalComputerBuilder SetCorpus(ICorpus corpus)
    {
        _corpus = corpus;
        return this;
    }

    public IPersonalComputerBuilder SetPowerSupply(IPowerSupply powerSupply)
    {
        _powerSupply = powerSupply;
        return this;
    }

    public IPersonalComputerBuilder SetWiFi(IWiFi wiFi)
    {
        _wiFi = wiFi;
        return this;
    }

    public AssemblingPCResults Build()
    {
        var pc = new PersonalComputer(
            _motherboard ?? throw new ArgumentNullException(nameof(_motherboard)),
            _cpu ?? throw new ArgumentNullException(nameof(_cpu)),
            _cooler ?? throw new ArgumentNullException(nameof(_cooler)),
            _ram ?? throw new ArgumentNullException(nameof(_ram)),
            _gpu,
            _drives ?? throw new ArgumentNullException(nameof(_drives)),
            _corpus ?? throw new ArgumentNullException(nameof(_corpus)),
            _powerSupply ?? throw new ArgumentNullException(nameof(_powerSupply)),
            _wiFi);

        ValidationResult result = _validator.Validate(pc);

        if (result is ValidationResult.NotSuitable)
            return new AssemblingPCResults.UnableToAssemble();

        if (result is ValidationResult.Warning)
            return new AssemblingPCResults.Warning(pc);

        return new AssemblingPCResults.Great(pc);
    }
}