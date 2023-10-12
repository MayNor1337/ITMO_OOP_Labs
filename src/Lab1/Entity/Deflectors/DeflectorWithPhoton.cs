using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;

public class DeflectorWithPhoton : IDeflector
{
    private readonly IDeflector _deflector;
    private int _amountWarhead = 3;

    public DeflectorWithPhoton(IDeflector deflector)
    {
        _deflector = deflector;
    }

    public TakeDamageResult ReflectRadiation()
    {
        if (_amountWarhead is 0)
            return new TakeDamageResult.Broken(0);

        --_amountWarhead;
        return new TakeDamageResult.Normal();
    }

    public TakeDamageResult TakeDamage(float damage)
    {
        return _deflector.TakeDamage(damage);
    }
}