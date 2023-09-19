using Itmo.ObjectOrientedProgramming.Lab1.ModelSettings.ObstaclesSettings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

public class SmallAsteroid : Obstacle
{
    public SmallAsteroid()
    {
        Damage = SmallAsteroidSettings.Damage;
        CollisionsAmount = SmallAsteroidSettings.CollisionsAmount;
    }
}