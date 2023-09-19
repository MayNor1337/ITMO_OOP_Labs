using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

public interface IProtectFromObstacles
{
     bool StrengthCheck(Obstacle obstacle, out float overDamage);
}