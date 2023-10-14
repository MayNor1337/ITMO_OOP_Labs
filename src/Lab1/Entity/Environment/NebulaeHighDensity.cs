using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;

public class NebulaeHighDensity : IEnviroment
{
    private readonly int _length;
    private readonly ObstacleStorage _obstacles;

    public NebulaeHighDensity(IEnumerable<INebulaeHighDensityObstacle> obstacles, int length)
    {
        _obstacles = new ObstacleStorage(obstacles);
        _length = length;
    }

    public PassageResult CalculationPassage(IShip ship)
    {
        if (ship is not IHaveJumpEngine jumpShip)
            return new PassageResult.Impossible();

        JumpResult jumpResult = jumpShip.CalculationSpentFuelPerJump(_length);

        if (jumpResult is not JumpResult.Success jumpResultSuccess)
            return new PassageResult.Impossible();

        DamageShipResult result = _obstacles.CheckingCollisionWithObstacles(ship);

        if (result is DamageShipResult.Destroyed)
            return new PassageResult.ShipDestroyed();

        if (result is DamageShipResult.CrewDied)
            return new PassageResult.CrewDied();

        return new PassageResult.Success(jumpResultSuccess.Fuel, jumpResultSuccess.Time);
    }
}