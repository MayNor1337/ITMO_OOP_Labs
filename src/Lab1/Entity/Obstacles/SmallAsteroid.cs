using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

public class SmallAsteroid : ICanExistInStandardSpace
{
    private float _damage;

    public SmallAsteroid()
    {
        _damage = 1;
    }

    public CollisionResult CollisionHandling(IShip ship)
    {
        return new CollisionResult.MaterialCollisionOccurred(_damage);
    }
}