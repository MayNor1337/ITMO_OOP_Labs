using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Corpuses;

public class LightCorpus : ICorpus
{
    private float _strengthPoints;

    public LightCorpus()
    {
        _strengthPoints = 1f;
    }

    public TakeDamageResult TakeDamage(float damage)
    {
        if (_strengthPoints <= damage)
            return new TakeDamageResult.Broken(damage - _strengthPoints);

        _strengthPoints -= damage;

        return new TakeDamageResult.Normal();
    }
}