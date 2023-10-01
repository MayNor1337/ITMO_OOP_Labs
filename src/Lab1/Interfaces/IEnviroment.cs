using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

public interface IEnviroment
{
    public PassageResult CalculationPassage(IShip ship);
}