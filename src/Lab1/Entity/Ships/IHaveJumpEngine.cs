using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;

public interface IHaveJumpEngine
{
    public JumpResult CalculationSpentFuelPerJump(int length);
}