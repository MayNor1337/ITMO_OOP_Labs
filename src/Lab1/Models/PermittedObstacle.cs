using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public static class PermittedObstacle
{
    public static Dictionary<int, Obstacle[]> PermittedObstacles { get; } = new Dictionary<int, Obstacle[]>()
    {
        { (int)EnvironmentType.StandardSpace, new Obstacle[] { new SmallAsteroid(), new Meteorite() } },
        { (int)EnvironmentType.NebulaeHighDensity, new Obstacle[] { new AntimatterFlares() } },
        { (int)EnvironmentType.NebulaeNitrineParticles, new Obstacle[] { new CosmoWhale() } },
    };
}