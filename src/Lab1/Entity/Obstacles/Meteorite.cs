using Itmo.ObjectOrientedProgramming.Lab1.ModelSettings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

public class Meteorite : Obstacle
{
    public Meteorite()
    {
        Damage = ObstaclesSettings.Meteorite.Damage;
        CollisionsAmount = ObstaclesSettings.Meteorite.CollisionsAmount;
    }
}