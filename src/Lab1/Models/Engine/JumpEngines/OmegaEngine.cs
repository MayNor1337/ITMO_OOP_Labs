using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine.JumpEngines;

public class OmegaEngine : IJumpEngine
{
    private readonly int _rangeOfTravel;
    private readonly float _fuelConsumption;
    private readonly float _jumpTime;

    public OmegaEngine()
    {
        _rangeOfTravel = 120;
        _fuelConsumption = 10f;
        _jumpTime = 1.5f;
    }

    public bool TryPassTrack(int lengthPath)
    {
        return lengthPath <= _rangeOfTravel;
    }

    public JumpResult Jumping(int length)
    {
        if (length <= _rangeOfTravel)
            return new JumpResult.Success(new GravitonMatter(_fuelConsumption), _jumpTime);

        return new JumpResult.Fail();
    }
}