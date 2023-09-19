using Itmo.ObjectOrientedProgramming.Lab1.ModelSettings.ObstaclesSettings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

public class CosmoWhale : Obstacle
{
    public CosmoWhale()
    {
        Damage = CosmoWhaleSettings.Damage;
        CollisionsAmount = CosmoWhaleSettings.CollisionsAmount;
    }
}