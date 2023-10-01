using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

public class Meteorite : ICanExistInStandardSpace
{
    private float _damage;

    public Meteorite()
    {
        _damage = 4;
    }

    public CollisionResult CollisionHandling(IShip ship)
    {
        return new CollisionResult.MaterialCollisionOccurred(_damage);
    }
}