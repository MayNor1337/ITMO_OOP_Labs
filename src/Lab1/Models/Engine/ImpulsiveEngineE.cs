using System;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class ImpulsiveEngineE : IImpulsiveEngine
{
    private readonly float _startFuelPrice;
    private readonly float _acceleration;
    private readonly FuelType _fuelConsumed;
    private readonly float _fuelСonsumptionPerSecond;

    public ImpulsiveEngineE()
    {
        _startFuelPrice = 50;
        _acceleration = 5f;
        _fuelConsumed = FuelType.ActivePlasma;
        _fuelСonsumptionPerSecond = 100f;
    }

    public Fuel CalculateSpentFuel(int lengthPath)
    {
        float time = (float)Math.Sqrt(_acceleration / (2 * lengthPath));
        float fuelCount = _startFuelPrice + (time * _fuelСonsumptionPerSecond);

        return new Fuel(_fuelConsumed, fuelCount);
    }
}