using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships.Component.Corpuses;

public class LightCorpus : ICorpus
{
    private float _strengthPoints;

    public LightCorpus()
    {
        _strengthPoints = 1f;
    }

    public TakeDamageResult TakeDamage(float damage)
    {
        _strengthPoints -= damage;

        if (_strengthPoints < 0)
            return new TakeDamageResult.Broke();

        return new TakeDamageResult.Normal();
    }
}