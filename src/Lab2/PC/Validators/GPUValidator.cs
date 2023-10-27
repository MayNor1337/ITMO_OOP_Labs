using Itmo.ObjectOrientedProgramming.Lab2.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.GPU;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.Validators;

public static class GPUValidator
{
    public static ValidationResult AddGpu(IGpu? gpu, ICpu cpu)
    {
        return GraphicValidation(gpu, cpu);
    }

    private static ValidationResult GraphicValidation(IGpu? gpu, ICpu cpu)
    {
        if (cpu is ICpuWithGraphicCore || gpu is not null)
            return new ValidationResult.Approach();

        return new ValidationResult.NotSuitable();
    }
}