using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine.JumpEngines;

public class AlphaEngine : IJumpEngine
{
    private readonly int _rangeOfTravel;
    private readonly float _fuelConsumption;

    public AlphaEngine()
    {
        _rangeOfTravel = 90;
        _fuelConsumption = 10;
    }

    public JumpResult CheckPossibilityJumping(int lenght)
    {
        if (lenght <= _rangeOfTravel)
            return new JumpResult.Success(new GravitonMatter(_fuelConsumption));

        return new JumpResult.Fail();
    }
}