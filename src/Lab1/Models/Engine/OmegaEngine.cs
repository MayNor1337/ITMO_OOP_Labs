using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class OmegaEngine : IEngine
{
    private readonly FuelType _fuelConsumed;
    private readonly float _rangeOfTravel;
    private readonly float _fuelConsumption;
    private readonly EnvironmentType[] _whereCanMove;

    public OmegaEngine()
    {
        _fuelConsumed = FuelType.GravitonMatter;
        _rangeOfTravel = 120f;
        _fuelConsumption = 10f;
        _whereCanMove = new[] { EnvironmentType.NebulaeHighDensity };
    }

    public bool TryPassTrack(EnvironmentType type, int lengthPath, out Fuel? fuel, out float time)
    {
        time = 0;
        if (_whereCanMove.Any(item => item == type) == false
            || lengthPath > _rangeOfTravel)
        {
            fuel = null;
            return false;
        }

        float fuelCount = (float)Math.Log(lengthPath, _fuelConsumption);
        fuel = new Fuel(_fuelConsumed, fuelCount);
        return true;
    }
}