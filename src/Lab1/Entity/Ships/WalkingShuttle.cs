using Itmo.ObjectOrientedProgramming.Lab1.Entity.Corpuses;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
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

    public DamageShipResult TakeDamage(float damage)
    {
        TakeDamageResult corpusResult = _corpus.TakeDamage(damage);
        if (corpusResult is TakeDamageResult.Normal)
            return new DamageShipResult.Survived();

        return new DamageShipResult.Destroyed();
    }

    public IFuel CalculatingCostsForPath(int length, out float time)
    {
        return _impulsiveEngine.CalculatingCostsForPath(length, out time);
    }
}