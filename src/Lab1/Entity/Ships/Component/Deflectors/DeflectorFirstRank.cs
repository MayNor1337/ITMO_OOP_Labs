using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships.Component.Deflectors;

public class DeflectorFirstRank : IDeflector
{
    private float _strengthPoints;

    public DeflectorFirstRank()
    {
        _strengthPoints = 2f;
    }

    public bool IsWorks { get; set; } = true;

    public TakeDamageResult TakeDamage(float damage)
    {
        _strengthPoints -= damage;
        if (_strengthPoints < 0)
        {
            IsWorks = false;
            return new TakeDamageResult.Broke();
        }

        return new TakeDamageResult.Normal();
    }
}