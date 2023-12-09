using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.Validators;

public class MainValidator : IValidator
{
    private int _amountOfWarning;
    private IEnumerable<IValidator> _validators;

    public MainValidator(IEnumerable<IValidator> validators)
    {
        _validators = validators;
    }

    public ValidationResult Validate(PersonalComputer personalComputer)
     {
         ValidationResult result;
         foreach (IValidator validator in _validators)
         {
             result = validator.Validate(personalComputer);

             if (result is ValidationResult.NotSuitable)
                 return result;

             if (result is ValidationResult.Warning warning)
                 _amountOfWarning += warning.Amount;
         }

         // Finaly
         if (_amountOfWarning != 0)
             return new ValidationResult.Warning(_amountOfWarning);

         return new ValidationResult.Approach();
     }
}