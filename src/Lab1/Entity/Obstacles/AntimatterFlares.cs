using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

public class AntimatterFlares : ICanExistInNebulaeHighDensity
{
    public AntimatterFlares()
    {
    }

    public CollisionResult CollisionHandling(IShip ship)
    {
        return new CollisionResult.RadiationCollisionOccurred();
    }
}