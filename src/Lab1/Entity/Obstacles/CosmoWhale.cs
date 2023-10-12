using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

public class CosmoWhale : INitrineParticlesObstacle
{
    private readonly float _damage;
    private readonly int _collisionsAmount;

    public CosmoWhale()
    {
        _damage = 40;
        _collisionsAmount = 1;
    }

    public DamageShipResult CollideTo(IShip ship)
    {
        if (ship is IHaveAntiNitrineEmitter)
        {
            return new DamageShipResult.Survived();
        }

        return ship.TakeDamage(_damage * _collisionsAmount);
    }
}