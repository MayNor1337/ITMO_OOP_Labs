using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

public interface IHaveJumpEngine
{
    public JumpResult CheckPossibilityJumping(int lenght);
}