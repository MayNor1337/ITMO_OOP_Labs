using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

public interface IJumpEngine
{
    public JumpResult CheckPossibilityJumping(int lenght);
}