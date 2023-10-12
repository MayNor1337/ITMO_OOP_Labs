using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine.JumpEngines;

public interface IJumpEngine
{
    public JumpResult Jumping(int length);
}