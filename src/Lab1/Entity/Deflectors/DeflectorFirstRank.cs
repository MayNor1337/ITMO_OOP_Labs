using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;

public class DeflectorFirstRank : IDeflector
{
    private float _strengthPoints;
    private bool _isWorks = true;

    public DeflectorFirstRank()
    {
        _strengthPoints = 2f;
    }

    public TakeDamageResult TakeDamage(float damage)
    {
        if (_isWorks is false)
            return new TakeDamageResult.Broken(damage);

        _strengthPoints -= damage;
        if (_strengthPoints < 0)
        {
            _isWorks = false;
            return new TakeDamageResult.Broken(Math.Abs(_strengthPoints));
        }

        return new TakeDamageResult.Normal();
    }
}