using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;

public class NebulaeNitrineParticles : IEnviroment
{
    private readonly int _length;
    private IObstacle[] _obstacles;

    public NebulaeNitrineParticles(IEnumerable<ICanExistInNebulaeNitrineParticles> obstacles, int length)
    {
        _obstacles = obstacles.ToArray();
        _length = length;
    }

    public PassageResult CalculationPassage(IShip ship)
    {
        if (ship is IHaveExponentialAcceleration == false)
            return new PassageResult.ImpossibleOvercome();

        foreach (IObstacle obstacle in _obstacles)
        {
            CollisionResult result = obstacle.CollisionHandling(ship);

            if (result is CollisionResult.CollisionAverted)
                continue;

            if (result is CollisionResult.MaterialCollisionOccurred physicalCollision)
            {
                if (ship.TakePhysicalDamage(physicalCollision.Damage) is DamageShipResult.Destroyed)
                {
                    return new PassageResult.ShipDestroyed();
                }

                continue;
            }

            if (result is CollisionResult.RadiationCollisionOccurred)
            {
                if (ship.TakeRadiationDamage() is DamageShipResult.Destroyed)
                {
                    return new PassageResult.CrewDied();
                }

                continue;
            }
        }

        return new PassageResult.Success(ship.CalculatingCostsForPath(_length));
    }
}