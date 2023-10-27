using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.Validators;

public static class PowerSupplyValidator
{
    public static ValidationResult Validate(IPowerSupply powerSupply, IEnumerable<IConsumeEnergy?> consumeEnergies)
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