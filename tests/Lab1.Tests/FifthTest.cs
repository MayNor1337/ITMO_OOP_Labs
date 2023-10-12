using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FifthTest
{
    [Fact]
    public void IShip_LetShip_WillTheShipsBeAbleToFlyInNebulaeHighDensity()
    {
        // Arrange
        var avgur = new Avgur(new DeflectorThirdRank());
        var stella = new Stella(new DeflectorFirstRank());
        var standardSpace = new NebulaeHighDensity(Array.Empty<INebulaeHighDensityObstacle>(), 80);
        var path = new Path(new[] { standardSpace });

        // Act
        PassingPathResult avgurResults = path.LetShip(avgur);
        PassingPathResult stellaResults = path.LetShip(stella);

        // Assert
        Assert.True(avgurResults is PassingPathResult.Success && stellaResults is PassingPathResult.Success);
    }
}