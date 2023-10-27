using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.Validators;

public static class CPUValidator
{
    public static ValidationResult AddCpuToMotherboard(ICPU cpu, IMotherboard motherboard)
    {
        if (motherboard.Soket != cpu.Socket)
            return new ValidationResult.NotSuitable();

        if (motherboard.Bios.SupportedCpu.Any(item => item == cpu.Name) is false)
            return new ValidationResult.NotSuitable();

        return new ValidationResult.Approach();
    }
}