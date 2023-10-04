using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class ImpulsiveEngineC : IImpulsiveEngine
{
    private readonly float _startFuelPrice;
    private readonly float _speed;
    private readonly float _fuelСonsumptionPerSecond;

    public ImpulsiveEngineC()
    {
        _startFuelPrice = 10f;
        _speed = 5f;
        _fuelСonsumptionPerSecond = 10f;
    }

    public GravitonMatter CalculatingCostsForPath(int lenght)
    {
        float time = lenght / _speed;
        float fuel = _startFuelPrice + (time * _fuelСonsumptionPerSecond);
        return new GravitonMatter(fuel);
    }
}