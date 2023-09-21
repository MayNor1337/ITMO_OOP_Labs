using System;
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
        Obstacle[] tempObstacles = Enumerable.ToArray(obstaclesVar);
        if (tempObstacles.Any(obstacle =>
                PermittedObstacle.PermittedObstacles[(int)type].All(permittedObstacle =>
                    obstacle.GetType() != permittedObstacle.GetType())))
            throw new ArgumentException("Unacceptable obstacles");

        _obstacles = tempObstacles;
    }

    public int Length { get; }
    public EnvironmentType Type { get; }

    public Obstacle[] GetObstacles()
    {
        return _obstacles;
    }
}