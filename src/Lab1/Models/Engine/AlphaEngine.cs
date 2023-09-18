using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.ModelSettings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class AlphaEngine : IEngine
{
    private readonly FuelType _fuelConsumed;
    private readonly float _rangeOfTravel;
    private readonly float _fuelConsumption;
    private readonly EnvironmentType[] _whereCanMove;

    public AlphaEngine()
    {
        _fuelConsumed = EngineSettings.JumpEngineAlpha.FuelConsumed;
        _rangeOfTravel = EngineSettings.JumpEngineAlpha.RangeOfTravel;
        _fuelConsumption = EngineSettings.JumpEngineAlpha.FuelConsumption;
        _whereCanMove = EngineSettings.JumpEngineAlpha.WhereCanMove;
    }

    public bool TryPassTrack(EnvironmentType type, int lengthPath, out Fuel? fuel)
    {
        if (_whereCanMove.Any(item => item == type) == false
            || lengthPath < _rangeOfTravel)
        {
            fuel = null;
            return false;
        }

        float fuelCount = _fuelConsumption * lengthPath;
        fuel = new Fuel(_fuelConsumed, fuelCount);
        return true;
    }
}