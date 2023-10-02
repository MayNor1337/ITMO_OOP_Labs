using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships.Component.Corpuses;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships.Component.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;

public class Vaclas : IShip, IHaveExponentialAcceleration, IHaveJumpEngine
{
    private readonly IImpulsiveEngine _impulsiveEngine;
    private readonly IJumpEngine _jumpEngine;
    private readonly IDeflector _deflector;
    private readonly ICorpus _corpus;

    public Vaclas(bool hasPotonicDeflectors = false)
    {
        _impulsiveEngine = new ImpulsiveEngineE();
        _jumpEngine = new GammaEngine();
        _deflector = hasPotonicDeflectors ? new DeflectorWithPhoton(new DeflectorFirstRank())
            : new DeflectorFirstRank();
        _corpus = new MediumCorpus();
    }

    public DamageShipResult TakePhysicalDamage(float damage)
    {
        if(_deflector)
    }

    public DamageShipResult TakeRadiationDamage()
    {
        if (_deflector is DeflectorWithPhoton photonDeflector)
            photonDeflector.ReflectRadiation();
    }
}