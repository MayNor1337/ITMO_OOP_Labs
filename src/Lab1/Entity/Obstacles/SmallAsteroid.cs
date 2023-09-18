using Itmo.ObjectOrientedProgramming.Lab1.ModelSettings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles
{
    public class SmallAsteroid : Obstacle
    {
        public SmallAsteroid()
        {
            Damage = ObstaclesSettings.SmallAsteroid.Damage;
            CollisionsAmount = ObstaclesSettings.SmallAsteroid.CollisionsAmount;
        }
    }
}