using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class ImpulsiveEngineE : IImpulsiveEngine
{
    private readonly float _startFuelPrice;
    private readonly float _acceleration;
    private readonly float _fuelСonsumptionPerSecond;

    public ImpulsiveEngineE()
    {
        _startFuelPrice = 50;
        _acceleration = 5f;
        _fuelСonsumptionPerSecond = 100f;
    }

    public EngineOperationData CalculatingCostsForPath(int length)
    {
        float time = (float)Math.Sqrt(_acceleration / (2 * length));
        float fuelCount = _startFuelPrice + (time * _fuelСonsumptionPerSecond);

        return new EngineOperationData(new ActivePlasma(fuelCount), time);
    }
}