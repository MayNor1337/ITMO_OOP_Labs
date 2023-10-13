using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;

public class DeflectorThirdRank : IDeflector
{
    private readonly float _damageDissipationFactor = 0.5f;
    private readonly float _damageThresholdForScattering = 10f;
    private float _strengthPoints;
    private bool _isWorks = true;

    public DeflectorThirdRank()
    {
        _strengthPoints = 20f;
    }

    public TakeDamageResult TakeDamage(float damage)
    {
        if (_isWorks is false)
            return new TakeDamageResult.Broken(damage);

        _strengthPoints -= damage < _damageThresholdForScattering
            ? _damageDissipationFactor * damage
            : damage;

        if (_strengthPoints <= 0)
        {
            _isWorks = false;
            return new TakeDamageResult.Broken(Math.Abs(_strengthPoints));
        }

        return new TakeDamageResult.Normal();
    }
}