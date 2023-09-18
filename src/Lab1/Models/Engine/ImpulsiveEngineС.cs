using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.ModelSettings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class ImpulsiveEngineС : IEngine
{
    private readonly float _startFuelPrice;
    private readonly float _speed;
    private readonly FuelType _fuelConsumed;
    private readonly float _fuelСonsumptionPerSecond;
    private readonly EnvironmentType[] _whereCanMove;

    public ImpulsiveEngineС()
    {
        _startFuelPrice = EngineSettings.ImpulsiveEngineС.StartFuelPrice;
        _speed = EngineSettings.ImpulsiveEngineС.Speed;
        _fuelConsumed = EngineSettings.ImpulsiveEngineС.FuelConsumed;
        _fuelСonsumptionPerSecond = EngineSettings.ImpulsiveEngineС.FuelСonsumptionPerSecond;
        _whereCanMove = EngineSettings.ImpulsiveEngineС.WhereCanMove;
    }

    public Fuel CalculateSpentFuel(int lengthPath)
    {
        float time = lengthPath / _speed;
        float fuel = _startFuelPrice + (time * _fuelСonsumptionPerSecond);
        return new Fuel(_fuelConsumed, fuel);
    }

    public bool TryPassTrack(EnvironmentType type, int lengthPath, out Fuel? fuel)
    {
        if (_whereCanMove.Any(item => item == type) == false)
        {
            fuel = null;
            return false;
        }

        float time = lengthPath / _speed;
        float fuelCount = _startFuelPrice + (time * _fuelСonsumptionPerSecond);
        fuel = new Fuel(_fuelConsumed, fuelCount);

        return true;
    }
}