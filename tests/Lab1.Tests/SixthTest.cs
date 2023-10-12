using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SixthTest
{
    [Fact]
    public void IShip_LetShip_WillTheShipsBeAbleToFlyInNebulaeNitrineParticles()
    {
        // Arrange
        var walkingShuttle = new WalkingShuttle();
        var vaclas = new Vaclas(new DeflectorFirstRank());

        var nebulaeNitrine = new NebulaeNitrineParticles(Array.Empty<INitrineParticlesObstacle>(), 160);
        var path = new Path(new[] { nebulaeNitrine });

        // Act
        PassingPathResult walkingShuttleResult = path.LetShip(walkingShuttle);
        PassingPathResult vaclasResult = path.LetShip(vaclas);

        // Assert
        Assert.True(walkingShuttleResult is PassingPathResult.Impossible && vaclasResult is PassingPathResult.Success);
    }
}