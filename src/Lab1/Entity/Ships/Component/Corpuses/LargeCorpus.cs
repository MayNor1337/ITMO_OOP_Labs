using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships.Component.Corpuses;

public class LargeCorpus : ICorpus
{
    private float _strengthPoints;
    private float _coefficientDispersion = 0.5f;

    public LargeCorpus()
    {
        _strengthPoints = 10f;
    }

    public TakeDamageResult TakeDamage(float damage)
    {
        _strengthPoints -= _coefficientDispersion * damage;

        if (_strengthPoints < 0)
            return new TakeDamageResult.Broke();

        return new TakeDamageResult.Normal();
    }
}