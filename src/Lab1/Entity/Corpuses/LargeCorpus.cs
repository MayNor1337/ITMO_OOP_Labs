using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Corpuses;

public class LargeCorpus : ICorpus
{
    private readonly float _damageDissipationFactor = 0.7f;
    private readonly float _damageThresholdForScattering = 5f;
    private float _strengthPoints;

    public LargeCorpus()
    {
        _strengthPoints = 10f;
    }

    public TakeDamageResult TakeDamage(float damage)
    {
        damage = damage < _damageThresholdForScattering
            ? _damageDissipationFactor * damage
            : damage;

        if (_strengthPoints <= damage)
            return new TakeDamageResult.Broken(damage - _strengthPoints);

        _strengthPoints -= damage;

        return new TakeDamageResult.Normal();
    }
}