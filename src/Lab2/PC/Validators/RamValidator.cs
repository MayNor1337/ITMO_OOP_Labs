using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.RAM;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.Validators;

public static class RamValidator
{
    public static ValidationResult AddRam(IRAM ram, IMotherboard motherboard, ICPU cpu)
    {
        ValidationResult result = AddRamToCpu(ram, cpu);
        if (result is not ValidationResult.Approach)
            return result;

        ValidationResult result1 = AddRamToMotherboard(ram, motherboard);
        if (result1 is not ValidationResult.Approach)
            return result;

        return new ValidationResult.Approach();
    }

    private static ValidationResult AddRamToMotherboard(IRAM ram, IMotherboard motherboard)
    {
        if (motherboard.StandartsDDR.Any(standard => standard == ram.DdrVersion))
            return new ValidationResult.Approach();

        return new ValidationResult.NotSuitable();
    }

    private static ValidationResult AddRamToCpu(IRAM ram, ICPU cpu)
    {
        if (cpu.SupportedMemoryFrequencies.Any(frec => ram.FrequenciesJEDEC.Contains(frec)))
            return new ValidationResult.Approach();

        return new ValidationResult.NotSuitable();
    }
}