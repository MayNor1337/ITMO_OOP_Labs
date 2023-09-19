using Itmo.ObjectOrientedProgramming.Lab1.ModelSettings.ObstaclesSettings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

public class Meteorite : Obstacle
{
    public Meteorite()
    {
        Damage = MeteoriteSettings.Damage;
        CollisionsAmount = MeteoriteSettings.CollisionsAmount;
    }
}