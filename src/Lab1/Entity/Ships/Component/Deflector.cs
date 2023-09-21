using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.ModelSettings.ShipSettings.Component;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships.Component;

public class Deflector : IProtectFromObstacles
{
    private int _rang;
    private float _healthPoint;
    private bool _isHavePhotonDeflector;
    private int _photonDeflectorCharges;

    public Deflector(int rang, bool isHavePhotonDeflector)
    {
        _rang = rang;
        _isHavePhotonDeflector = isHavePhotonDeflector;
        _healthPoint = DeflectorSettings.HealthPoint[_rang];
        _photonDeflectorCharges = DeflectorSettings.PhotonDeflectorCharges;
    }

    public bool StrengthCheck(Obstacle obstacle, out float overDamage)
    {
        if (obstacle == null)
        {
            throw new ArgumentNullException(nameof(obstacle));
        }

        if (obstacle is AntimatterFlares)
        {
            if (_isHavePhotonDeflector && _photonDeflectorCharges > 0)
            {
                _photonDeflectorCharges -= 1;
                overDamage = 0;
                return true;
            }
            else
            {
                overDamage = 0;
                return false;
            }
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
}