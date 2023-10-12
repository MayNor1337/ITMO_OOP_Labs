using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

public class SmallAsteroid : IStandardSpaceObstacle
{
    private readonly float _damage;

    public SmallAsteroid()
    {
        _damage = 1;
    }

    public DamageShipResult CollideTo(IShip ship)
    {
        return ship.TakeDamage(_damage);
    }
}