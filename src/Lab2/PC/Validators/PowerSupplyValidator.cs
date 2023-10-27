using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.Validators;

public class PowerSupplyValidator : IValidator
{
    public ValidationResult Validate(PersonalComputer personalComputer) =>
        ConsumptionCalculationAndVerification(
            personalComputer.PowerSupply,
            new IConsumeEnergy?[]
            {
                personalComputer.Cpu, personalComputer.Ram, personalComputer.Gpu, personalComputer.WiFi,
            }.Concat(personalComputer.Drives));

    private static ValidationResult ConsumptionCalculationAndVerification(IPowerSupply powerSupply, IEnumerable<IConsumeEnergy?> consumeEnergies)
    {
        int generalConsume = 0;

        foreach (IConsumeEnergy? component in consumeEnergies)
        {
            if (component is not null)
                generalConsume += component.PowerConsumption;
        }

        if (generalConsume <= powerSupply.MaximumRcommendedLoad)
            return new ValidationResult.Approach();

        if (generalConsume <= powerSupply.PeakLoad)
            return new ValidationResult.Warning(1);

        return new ValidationResult.NotSuitable();
    }
}