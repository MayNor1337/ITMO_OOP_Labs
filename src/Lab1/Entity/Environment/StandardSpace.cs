using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;

public class StandardSpace : IEnviroment
{
    private readonly int _length;
    private readonly ObstacleStorage<IStandardSpaceObstacle> _obstacles;

    public StandardSpace(IEnumerable<IStandardSpaceObstacle> obstacles, int length)
    {
        _obstacles = new ObstacleStorage<IStandardSpaceObstacle>(obstacles);
        _length = length;
    }

    public PassageResult CalculationPassage(IShip ship)
    {
        DamageShipResult result = _obstacles.CheckingCollisionWithObstacles(ship);

        if (result is DamageShipResult.Destroyed)
            return new PassageResult.ShipDestroyed();

        if (result is DamageShipResult.CrewDied)
            return new PassageResult.CrewDied();

        return new PassageResult.Success(ship.CalculatingCostsForPath(_length, out float time), time);
    }
}