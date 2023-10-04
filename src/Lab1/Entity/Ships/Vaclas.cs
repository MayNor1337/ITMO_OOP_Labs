using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships.Component.Corpuses;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships.Component.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
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
        IDeflector standardDeflector = new DeflectorFirstRank();
        _deflector = hasPotonicDeflectors ? new DeflectorWithPhoton(standardDeflector)
            : standardDeflector;
        _corpus = new MediumCorpus();
    }

    public DamageShipResult TakePhysicalDamage(float damage)
    {
        TakeDamageResult result = _deflector.TakeDamage(damage);
        if (result is TakeDamageResult.Broke)
        {
            if (result is TakeDamageResult.BrokeAndOverDamage brokeResult)
            {
                damage = brokeResult.OverDamage;
            }
            else
            {
                return new DamageShipResult.Survived();
            }
        }

        TakeDamageResult corpusResult = _corpus.TakeDamage(damage);
        if (corpusResult is TakeDamageResult.Normal)
            return new DamageShipResult.Survived();

        return new DamageShipResult.Destroyed();
    }

    public DamageShipResult TakeRadiationDamage()
    {
        if (_deflector is DeflectorWithPhoton photonDeflector == false) return new DamageShipResult.Destroyed();

        TakeDamageResult result = photonDeflector.ReflectRadiation();
        if (result is TakeDamageResult.Normal)
            return new DamageShipResult.Survived();

        return new DamageShipResult.Destroyed();
    }

    public GravitonMatter CalculatingCostsForPath(int lenght)
    {
        return _impulsiveEngine.CalculatingCostsForPath(lenght);
    }

    public JumpResult CheckPossibilityJumping(int lenght)
    {
        return _jumpEngine.CheckPossibilityJumping(lenght);
    }
}