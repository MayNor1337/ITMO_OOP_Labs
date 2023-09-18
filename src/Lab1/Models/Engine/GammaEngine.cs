using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.ModelSettings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class GammaEngine : IEngine
{
    private readonly FuelType _fuelConsumed;
    private readonly float _rangeOfTravel;
    private readonly float _fuelConsumption;
    private readonly EnvironmentType[] _whereCanMove;

    public GammaEngine()
    {
        _fuelConsumed = EngineSettings.JumpEngineGamma.FuelConsumed;
        _rangeOfTravel = EngineSettings.JumpEngineGamma.RangeOfTravel;
        _fuelConsumption = EngineSettings.JumpEngineGamma.FuelConsumption;
        _whereCanMove = EngineSettings.JumpEngineGamma.WhereCanMove;
    }

    public bool TryPassTrack(EnvironmentType type, int lengthPath, out Fuel? fuel)
    {
        if (_whereCanMove.Any(item => item == type) == false
            || lengthPath < _rangeOfTravel)
        {
            fuel = null;
            return false;
        }

        float fuelCount = (_fuelConsumption * lengthPath) * (_fuelConsumption * lengthPath);
        fuel = new Fuel(_fuelConsumed, fuelCount);
        return true;
    }
}