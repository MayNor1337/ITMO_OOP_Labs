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
        _strengthPoints -= damage < _damageThresholdForScattering
            ? _damageDissipationFactor * damage
            : damage;

        if (_strengthPoints < 0)
            return new TakeDamageResult.Broken(0);

        return new TakeDamageResult.Normal();
    }
}