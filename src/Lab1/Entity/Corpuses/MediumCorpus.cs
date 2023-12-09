using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Corpuses;

public class MediumCorpus : ICorpus
{
    private float _strengthPoints;

    public MediumCorpus()
    {
        _strengthPoints = 3f;
    }

    public TakeDamageResult TakeDamage(float damage)
    {
        if (_strengthPoints <= damage)
            return new TakeDamageResult.Broken(damage - _strengthPoints);

        _strengthPoints -= damage;

        return new TakeDamageResult.Normal();
    }
}