using Itmo.ObjectOrientedProgramming.Lab2.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.GPU;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.Validators;

public static class GPUValidator
{
    public static ValidationResult AddGpu(IGPU? gpu, ICPU cpu)
    {
        return GraphicValidation(gpu, cpu);
    }

    private static ValidationResult GraphicValidation(IGPU? gpu, ICPU cpu)
    {
        if (cpu is ICPUWithGC || gpu is not null)
            return new ValidationResult.Approach();

        return new ValidationResult.NotSuitable();
    }
}