namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

public abstract class Obstacle
{
    public float Damage { get; protected set; }
    public int CollisionsAmount { get; protected set; }
}