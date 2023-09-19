using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.ModelSettings.EngineSettings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class ImpulsiveEngineE : IEngine
{
    private readonly float _startFuelPrice;
    private readonly float _acceleration;
    private readonly FuelType _fuelConsumed;
    private readonly float _fuelСonsumptionPerSecond;
    private readonly EnvironmentType[] _whereCanMove;

    public ImpulsiveEngineE()
    {
        _startFuelPrice = ImpulsiveEngineESettings.StartFuelPrice;
        _acceleration = ImpulsiveEngineESettings.Acceleration;
        _fuelConsumed = ImpulsiveEngineESettings.FuelConsumed;
        _fuelСonsumptionPerSecond = ImpulsiveEngineESettings.FuelСonsumptionPerSecond;
        _whereCanMove = ImpulsiveEngineESettings.WhereCanMove;
    }

    public bool TryPassTrack(EnvironmentType type, int lengthPath, out Fuel? fuel)
    {
        if (_whereCanMove.Any(item => item == type) == false)
        {
            fuel = null;
            return false;
        }

        float time = (float)Math.Sqrt(_acceleration / (2 * lengthPath));
        float fuelCount = _startFuelPrice + (time * _fuelСonsumptionPerSecond);
        fuel = new Fuel(_fuelConsumed, fuelCount);

        return true;
    }
}