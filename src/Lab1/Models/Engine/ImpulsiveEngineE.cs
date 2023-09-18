using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.ModelSettings;

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
        _startFuelPrice = EngineSettings.ImpulsiveEngineE.StartFuelPrice;
        _acceleration = EngineSettings.ImpulsiveEngineE.Acceleration;
        _fuelConsumed = EngineSettings.ImpulsiveEngineE.FuelConsumed;
        _fuelСonsumptionPerSecond = EngineSettings.ImpulsiveEngineE.FuelСonsumptionPerSecond;
        _whereCanMove = EngineSettings.ImpulsiveEngineE.WhereCanMove;
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