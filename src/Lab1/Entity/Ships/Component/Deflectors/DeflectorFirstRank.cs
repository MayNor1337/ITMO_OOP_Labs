using System;
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

    public bool IsWorks { get; set; }

    public TakeDamageResult TakeDamage(float damage)
    {
        if (IsWorks == false)
            return new TakeDamageResult.BrokeAndOverDamage(damage);

        _strengthPoints -= damage;
        if (_strengthPoints < 0)
        {
            IsWorks = false;
            return new TakeDamageResult.BrokeAndOverDamage(Math.Abs(_strengthPoints));
        }

        return new TakeDamageResult.Normal();
    }
}