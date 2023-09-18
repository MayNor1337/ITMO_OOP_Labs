using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.ModelSettings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class OmegaEngine : IEngine
{
    private readonly FuelType _fuelConsumed;
    private readonly float _rangeOfTravel;
    private readonly float _fuelConsumption;
    private readonly EnvironmentType[] _whereCanMove;

    public OmegaEngine()
    {
        _fuelConsumed = EngineSettings.JumpEngineOmega.FuelConsumed;
        _rangeOfTravel = EngineSettings.JumpEngineOmega.RangeOfTravel;
        _fuelConsumption = EngineSettings.JumpEngineOmega.FuelConsumption;
        _whereCanMove = EngineSettings.JumpEngineOmega.WhereCanMove;
    }

    public bool TryPassTrack(EnvironmentType type, int lengthPath, out Fuel? fuel)
    {
        if (_whereCanMove.Any(item => item == type) == false
            || lengthPath < _rangeOfTravel)
        {
            fuel = null;
            return false;
        }

        float fuelCount = (float)Math.Log(lengthPath, _fuelConsumption);
        fuel = new Fuel(_fuelConsumed, fuelCount);
        return true;
    }
}