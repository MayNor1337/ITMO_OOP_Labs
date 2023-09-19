using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;

public record Section
{
    private readonly Obstacle[] _obstacles;

    public Section(int length, EnvironmentType type, IEnumerable<Obstacle> obstaclesVar)
    {
        Length = length;
        Type = type;
        _obstacles = Enumerable.ToArray<Obstacle>(PermittedObstacle.PermittedObstacles[(int)type].Where(obj =>
            obstaclesVar.Any(obstacle => obj.GetType() == obstacle.GetType())));
    }

    public int Length { get; }
    public EnvironmentType Type { get; }

    public Obstacle[] GetObstacles()
    {
        return _obstacles;
    }
}