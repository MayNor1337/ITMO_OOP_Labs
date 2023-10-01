using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

public interface IObstacle
{
    public CollisionResult CollisionHandling(IShip ship);
}