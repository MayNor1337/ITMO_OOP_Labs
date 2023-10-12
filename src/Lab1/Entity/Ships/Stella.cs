using Itmo.ObjectOrientedProgramming.Lab1.Entity.Corpuses;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;

public class Stella : IShipWithDeflector, IHaveJumpEngine
{
    private readonly IImpulsiveEngine _impulsiveEngine;
    private readonly IJumpEngine _jumpEngine;
    private readonly ICorpus _corpus;

    public Stella(IDeflector deflector)
    {
        _impulsiveEngine = new ImpulsiveEngineC();
        _jumpEngine = new OmegaEngine();
        Deflector = deflector;
        _corpus = new LightCorpus();
    }

    public IDeflector Deflector { get; private set; }

    public DamageShipResult TakeDamage(float damage)
    {
        TakeDamageResult result = Deflector.TakeDamage(damage);
        if (result is not TakeDamageResult.Broken broken
            || broken.OverDamage == 0)
            return new DamageShipResult.Survived();

        TakeDamageResult corpusResult = _corpus.TakeDamage(broken.OverDamage);
        if (corpusResult is TakeDamageResult.Normal)
            return new DamageShipResult.Survived();

        return new DamageShipResult.Destroyed();
    }

    public IFuel CalculatingCostsForPath(int length, out float time)
    {
        return _impulsiveEngine.CalculatingCostsForPath(length, out time);
    }

    public JumpResult CalculationSpentFuelPerJump(int length)
    {
        return _jumpEngine.Jumping(length);
    }
}