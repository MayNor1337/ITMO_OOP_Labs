using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

public class Meteorite : IStandardSpaceObstacle
{
    private readonly float _damage;

    public Meteorite()
    {
        _damage = 4;
    }

    public DamageShipResult CollideTo(IShip ship)
    {
        return ship.TakeDamage(_damage);
    }
}