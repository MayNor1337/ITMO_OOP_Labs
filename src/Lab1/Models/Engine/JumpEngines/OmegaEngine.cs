using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine.JumpEngines;

public class OmegaEngine : IJumpEngine
{
    private readonly int _rangeOfTravel;
    private readonly float _fuelConsumption;

    public OmegaEngine()
    {
        _rangeOfTravel = 120;
        _fuelConsumption = 10f;
    }

    public bool TryPassTrack(int lengthPath)
    {
        return lengthPath <= _rangeOfTravel;
    }

    public JumpResult CheckPossibilityJumping(int lenght)
    {
        if (lenght <= _rangeOfTravel)
            return new JumpResult.Success(new GravitonMatter(_fuelConsumption));

        return new JumpResult.Fail();
    }
}