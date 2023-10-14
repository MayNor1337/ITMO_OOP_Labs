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

        if (_strengthPoints <= damage)
        {
            _isWorks = false;
            return new TakeDamageResult.Broken(damage - _strengthPoints);
        }

        _strengthPoints -= damage;

        return new TakeDamageResult.Normal();
    }
}