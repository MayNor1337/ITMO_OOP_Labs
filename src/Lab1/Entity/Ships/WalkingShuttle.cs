using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships.Component.Corpuses;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;

public class WalkingShuttle : IShip
{
    private readonly IImpulsiveEngine _impulsiveEngine;
    private readonly ICorpus _corpus;

    public WalkingShuttle()
    {
        _impulsiveEngine = new ImpulsiveEngineC();
        _corpus = new LightCorpus();
    }

    public DamageShipResult TakePhysicalDamage(float damage)
    {
        TakeDamageResult result = _corpus.TakeDamage(damage);

        if (result is TakeDamageResult.Broke)
            return new DamageShipResult.Destroyed();

        return new DamageShipResult.Survived();
    }

    public DamageShipResult TakeRadiationDamage()
    {
        return new DamageShipResult.Destroyed();
    }
}