using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Cooler;
using Itmo.ObjectOrientedProgramming.Lab2.Corpus;
using Itmo.ObjectOrientedProgramming.Lab2.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.Validators;

public class CoolerValidator : IValidator
{
    public ValidationResult Validate(PersonalComputer personalComputer)
    {
        return AddCoolerToPC(
            personalComputer.Cooler,
            personalComputer.Corpus,
            personalComputer.Cpu,
            personalComputer.Motherboard);
    }

    private static ValidationResult AddCoolerToPC(ICooler cooler, ICorpus corpus, ICpu cpu, IMotherboard motherboard)
    {
        int countOfWarning = 0;

        ValidationResult result = AddCoolerToCorpus(cooler, corpus);
        if (result is ValidationResult.NotSuitable)
            return result;

        if (result is ValidationResult.Warning warning)
            countOfWarning += warning.Amount;

        result = AddCoolerToCpu(cooler, cpu);
        if (result is ValidationResult.NotSuitable)
            return result;

        if (result is ValidationResult.Warning warning2)
            countOfWarning += warning2.Amount;

        result = AddCoolerToMotherboard(cooler, motherboard);
        if (result is ValidationResult.NotSuitable)
            return result;

        if (result is ValidationResult.Warning warning3)
            countOfWarning += warning3.Amount;

        if (countOfWarning is not 0)
            return new ValidationResult.Warning(countOfWarning);

        return new ValidationResult.Approach();
    }

    private static ValidationResult AddCoolerToCorpus(ICooler cooler, ICorpus corpus)
    {
        if (cooler.Height <= corpus.CorpusHeight)
            return new ValidationResult.Approach();

        return new ValidationResult.NotSuitable();
    }

    private static ValidationResult AddCoolerToCpu(ICooler cooler, ICpu cpu)
    {
        if (cooler.MaxTDP >= cpu.Tdp)
            return new ValidationResult.Approach();

        return new ValidationResult.Warning(1);
    }

    private static ValidationResult AddCoolerToMotherboard(ICooler cooler, IMotherboard motherboard)
    {
        if (cooler.SupportedSocets.Any(soket => soket == motherboard.Soket))
            return new ValidationResult.Approach();

        return new ValidationResult.NotSuitable();
    }
}