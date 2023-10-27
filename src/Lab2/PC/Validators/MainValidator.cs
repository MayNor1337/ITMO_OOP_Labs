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

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.Validators;

public class MainValidator
{
    private int _amountOfWarning;

    public ValidationResult Validate(
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
         // CPU Validate
         ValidationResult result = CPUValidator.AddCpuToMotherboard(cpu, motherboard);

         if (result is ValidationResult.NotSuitable)
             return result;

         if (result is ValidationResult.Warning warning)
             _amountOfWarning += warning.Amount;

         // COOLER Validate
         result = CoolerValidator.AddCoolerToPC(cooler, corpus, cpu, motherboard);

         if (result is ValidationResult.NotSuitable)
             return result;

         if (result is ValidationResult.Warning warning2)
             _amountOfWarning += warning2.Amount;

         // Ram validate
         result = RamValidator.AddRam(ram, motherboard, cpu);

         if (result is ValidationResult.NotSuitable)
             return result;

         if (result is ValidationResult.Warning warning3)
             _amountOfWarning += warning3.Amount;

         // GPU VALIDATION
         result = GPUValidator.AddGpu(gpu, cpu);

         if (result is ValidationResult.NotSuitable)
             return result;

         if (result is ValidationResult.Warning warning4)
             _amountOfWarning += warning4.Amount;

         // Power Supply valid
         result = PowerSupplyValidator.Validate(powerSupply, new IConsumeEnergy?[] { cpu, ram, gpu, wiFi }.Concat(drives));

         if (result is ValidationResult.NotSuitable)
             return result;

         if (result is ValidationResult.Warning warning5)
             _amountOfWarning += warning5.Amount;

         // Finaly
         if (_amountOfWarning != 0)
             return new ValidationResult.Warning(_amountOfWarning);

         return new ValidationResult.Approach();
     }
}