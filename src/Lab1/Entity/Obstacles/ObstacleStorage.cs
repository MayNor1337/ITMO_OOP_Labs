using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

public class ObstacleStorage
{
    private IObstacle[] _obstacles;

    public ObstacleStorage(IEnumerable<IObstacle> obstacles)
    {
        _obstacles = obstacles.ToArray();
    }

    public DamageShipResult CheckingCollisionWithObstacles(IShip ship)
    {
        foreach (IObstacle obstacle in _obstacles)
        {
            DamageShipResult result = obstacle.CollideTo(ship);

            if (result is not DamageShipResult.Survived)
                return result;
        }

        return new DamageShipResult.Survived();
    }
}