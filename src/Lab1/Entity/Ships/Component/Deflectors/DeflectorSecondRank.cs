using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships.Component.Deflectors;

public class DeflectorSecondRank
{
    private float _strengthPoints;

    public DeflectorSecondRank()
    {
        _strengthPoints = 16f;
    }

    public bool IsWorks { get; private set; } = true;

    public TakeDamageResult TakeDamage(float damage)
    {
        _strengthPoints -= 0.8f * damage;
        if (_strengthPoints < 0)
        {
            IsWorks = false;
            return new TakeDamageResult.Broke();
        }

        return new TakeDamageResult.Normal();
    }
}