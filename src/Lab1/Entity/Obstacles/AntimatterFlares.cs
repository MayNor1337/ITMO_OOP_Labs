using Itmo.ObjectOrientedProgramming.Lab1.ModelSettings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

public class AntimatterFlares : Obstacle
{
    public AntimatterFlares()
    {
        Damage = ObstaclesSettings.AntimatterFlares.Damage;
        CollisionsAmount = ObstaclesSettings.AntimatterFlares.CollisionsAmount;
    }
}