using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

public class CosmoWhale : ICanExistInNebulaeNitrineParticles
{
    private float _damage;
    private int _collisionsAmount;

    public CosmoWhale()
    {
        _damage = 40;
        _collisionsAmount = 1;
    }

    public CollisionResult CollisionHandling(IShip ship)
    {
        if (ship is IHaveAntiNitrineEmitter)
        {
            return new CollisionResult.CollisionAverted();
        }
        else
        {
            return new CollisionResult.MaterialCollisionOccurred(_damage * _collisionsAmount);
        }
    }
}