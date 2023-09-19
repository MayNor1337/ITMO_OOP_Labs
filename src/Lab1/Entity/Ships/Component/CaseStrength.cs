using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.ModelSettings.ShipSettings.Component;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships.Component;

public class CaseStrength : IProtectFromObstacles
{
    private int _rang;
    private float _healthPoint;

    public CaseStrength(int rang)
    {
        _rang = rang;
        _healthPoint = CaseStrengthSettings.HealthPoint[_rang];
    }

    public bool StrengthCheck(Obstacle obstacle, out float overDamage)
    {
        if (obstacle == null)
        {
            throw new ArgumentNullException(nameof(obstacle));
        }

        if (obstacle is AntimatterFlares)
        {
            overDamage = 0;
            return false;
        }

        float damage = obstacle.Damage * obstacle.CollisionsAmount;

        if (damage > _healthPoint)
        {
            overDamage = damage - _healthPoint;
            return false;
        }

        overDamage = 0;
        return true;
    }

    public bool CheckOverDamage(float damage)
    {
        if (damage > _healthPoint)
            return false;

        _healthPoint -= damage;
        return true;
    }
}