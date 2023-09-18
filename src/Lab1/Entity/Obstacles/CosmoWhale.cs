using Itmo.ObjectOrientedProgramming.Lab1.ModelSettings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

public class CosmoWhale : Obstacle
{
    public CosmoWhale()
    {
        Damage = ObstaclesSettings.CosmoWhale.Damage;
        CollisionsAmount = ObstaclesSettings.CosmoWhale.CollisionsAmount;
    }
}