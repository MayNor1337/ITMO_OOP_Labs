namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

public abstract record CollisionResult
{
    private CollisionResult() { }

    public sealed record CollisionAverted : CollisionResult;

    public sealed record MaterialCollisionOccurred(float Damage) : CollisionResult;

    public sealed record RadiationCollisionOccurred() : CollisionResult;
}