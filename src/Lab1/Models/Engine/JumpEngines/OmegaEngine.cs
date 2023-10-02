using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine.JumpEngines;

public class OmegaEngine : IJumpEngine
{
    private readonly FuelType _fuelConsumed;
    private readonly float _rangeOfTravel;
    private readonly float _fuelConsumption;

    public OmegaEngine()
    {
        _fuelConsumed = FuelType.GravitonMatter;
        _rangeOfTravel = 120f;
        _fuelConsumption = 10f;
    }

    public bool TryPassTrack(int lengthPath)
    {
        return lengthPath <= _rangeOfTravel;
    }
}