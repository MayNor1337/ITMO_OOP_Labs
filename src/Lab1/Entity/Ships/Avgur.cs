using Itmo.ObjectOrientedProgramming.Lab1.Entity.Corpuses;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;

public class Avgur : IShipWithDeflector, IHaveJumpEngine, IHaveExponentialAcceleration
{
    private readonly IImpulsiveEngine _impulsiveEngine;
    private readonly IJumpEngine _jumpEngine;
    private readonly ICorpus _corpus;

    public Avgur(IDeflector deflector)
    {
        _impulsiveEngine = new ImpulsiveEngineE();
        _jumpEngine = new AlphaEngine();
        Deflector = deflector;
        _corpus = new LargeCorpus();
    }

    public IDeflector Deflector { get; private set; }

    public DamageShipResult TakeDamage(float damage)
    {
        TakeDamageResult result = Deflector.TakeDamage(damage);
        if (result is not TakeDamageResult.Broken broken
            || broken.OverDamage is 0)
            return new DamageShipResult.Survived();

        TakeDamageResult corpusResult = _corpus.TakeDamage(broken.OverDamage);
        if (corpusResult is TakeDamageResult.Normal)
            return new DamageShipResult.Survived();

        return new DamageShipResult.Destroyed();
    }

    public EngineOperationData CalculatingCostsForPath(int length)
    {
        return _impulsiveEngine.CalculatingCostsForPath(length);
    }

    public JumpResult CalculationSpentFuelPerJump(int length)
    {
        return _jumpEngine.Jumping(length);
    }
}