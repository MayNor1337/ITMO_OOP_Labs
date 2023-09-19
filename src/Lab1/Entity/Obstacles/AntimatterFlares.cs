using Itmo.ObjectOrientedProgramming.Lab1.ModelSettings.ObstaclesSettings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

public class AntimatterFlares : Obstacle
{
    public AntimatterFlares()
    {
        Damage = AntimatterFlaresSettings.Damage;
        CollisionsAmount = AntimatterFlaresSettings.CollisionsAmount;
    }
}