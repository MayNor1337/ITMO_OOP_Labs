using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships.Component.Deflectors;

public class DeflectorThirdRank : IDeflector
{
    private float _strengthPoints;

    public DeflectorThirdRank()
    {
        _strengthPoints = 20f;
    }

    public bool IsWorks { get; private set; } = true;

    public TakeDamageResult TakeDamage(float damage)
    {
        if (IsWorks == false)
            return new TakeDamageResult.BrokeAndOverDamage(damage);

        _strengthPoints -= 0.5f * damage;
        if (_strengthPoints < 0)
        {
            IsWorks = false;
            return new TakeDamageResult.Broke();
        }

        return new TakeDamageResult.Normal();
    }
}