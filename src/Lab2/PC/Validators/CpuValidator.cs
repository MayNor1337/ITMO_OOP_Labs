using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.Validators;

public class CpuValidator : IValidator
{
    public ValidationResult Validate(PersonalComputer personalComputer)
    {
        ICpu cpu = personalComputer.Cpu;
        IMotherboard motherboard = personalComputer.Motherboard;
        return AddCpuToMotherboard(cpu, motherboard);
    }

    private static ValidationResult AddCpuToMotherboard(ICpu cpu, IMotherboard motherboard)
    {
        if (motherboard.Soket != cpu.Socket)
            return new ValidationResult.NotSuitable();

        if (motherboard.Bios.SupportedCpu.Any(item => item == cpu.Name) is false)
            return new ValidationResult.NotSuitable();

        return new ValidationResult.Approach();
    }
}