using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

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
        _startFuelPrice = 50;
        _acceleration = 5f;
        _fuelConsumed = FuelType.ActivePlasma;
        _fuelСonsumptionPerSecond = 100f;
        _whereCanMove = new[] { EnvironmentType.StandardSpace, EnvironmentType.NebulaeNitrineParticles, };
    }

    public bool TryPassTrack(EnvironmentType type, int lengthPath, out Fuel? fuel, out float time)
    {
        time = 0;
        if (_whereCanMove.Any(item => item == type) == false)
        {
            fuel = null;
            return false;
        }

        time = (float)Math.Sqrt(_acceleration / (2 * lengthPath));
        float fuelCount = _startFuelPrice + (time * _fuelСonsumptionPerSecond);
        fuel = new Fuel(_fuelConsumed, fuelCount);

        return true;
    }
}