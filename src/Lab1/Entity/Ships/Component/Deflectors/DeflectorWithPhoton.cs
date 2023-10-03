using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships.Component.Deflectors;

public class DeflectorWithPhoton : IDeflector
{
    private readonly IDeflector _deflector;
    private int _amountWarhead = 3;

    public DeflectorWithPhoton(IDeflector deflector)
    {
        _deflector = deflector;
    }

    public bool IsWorks => _deflector.IsWorks;

    public TakeDamageResult ReflectRadiation()
    {
        --_amountWarhead;
        if (_amountWarhead < 0)
            return new TakeDamageResult.Broke();

        return new TakeDamageResult.Normal();
    }

    public TakeDamageResult TakeDamage(float damage)
    {
        return _deflector.TakeDamage(damage);
    }
}