using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;

public class NebulaeNitrineParticles : IEnviroment
{
    private readonly int _length;
    private readonly ObstacleStorage<INitrineParticlesObstacle> _obstacles;

    public NebulaeNitrineParticles(IEnumerable<INitrineParticlesObstacle> obstacles, int length)
    {
        _obstacles = new ObstacleStorage<INitrineParticlesObstacle>(obstacles);
        _length = length;
    }

    public PassageResult CalculationPassage(IShip ship)
    {
        if (ship is not IHaveExponentialAcceleration)
            return new PassageResult.Impossible();

        DamageShipResult result = _obstacles.CheckingCollisionWithObstacles(ship);

        if (result is DamageShipResult.Destroyed)
            return new PassageResult.ShipDestroyed();

        if (result is DamageShipResult.CrewDied)
            return new PassageResult.CrewDied();

        return new PassageResult.Success(ship.CalculatingCostsForPath(_length, out float time), time);
    }
}