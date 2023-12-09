﻿using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;

public class DeflectorSecondRank : IDeflector
{
    private readonly float _damageDissipationFactor = 0.8f;
    private readonly float _damageThresholdForScattering = 5f;
    private float _strengthPoints;
    private bool _isWorks = true;

    public DeflectorSecondRank()
    {
        _strengthPoints = 16f;
    }

    public TakeDamageResult TakeDamage(float damage)
    {
        if (_isWorks is false)
            return new TakeDamageResult.Broken(damage);

        damage = damage < _damageThresholdForScattering
            ? _damageDissipationFactor * damage
            : damage;

        if (_strengthPoints <= damage)
        {
            _isWorks = false;
            return new TakeDamageResult.Broken(damage - _strengthPoints);
        }

        _strengthPoints -= damage;

        return new TakeDamageResult.Normal();
    }
}