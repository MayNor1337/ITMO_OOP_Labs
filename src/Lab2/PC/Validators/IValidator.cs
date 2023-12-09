namespace Itmo.ObjectOrientedProgramming.Lab2.PC.Validators;

public interface IValidator
{
    ValidationResult Validate(PersonalComputer personalComputer);
}