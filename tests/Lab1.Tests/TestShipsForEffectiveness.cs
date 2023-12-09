using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class TestShipsForEffectiveness
{
    // Fourth Test
    [Fact]
    public void IShip_LetShip_WhoIsCheaperInStandardSpace()
    {
        // Arrange
        var walkingShuttle = new WalkingShuttle();
        var vaclas = new Vaclas(new DeflectorFirstRank());
        var standardSpace = new StandardSpace(Array.Empty<IStandardSpaceObstacle>(), 20);
        var path = new Path(new[] { standardSpace });
        var fuelStockMarket = new FuelStockMarket();

        // Act
        PassingPathResult walkingShuttleResult = path.LetShip(walkingShuttle);
        PassingPathResult vaclasResults = path.LetShip(vaclas);

        if (walkingShuttleResult is not PassingPathResult.Success walkingShuttleFuel)
        {
            Assert.True(false);
            return;
        }

        if (vaclasResults is not PassingPathResult.Success vaclasFuel)
        {
            Assert.True(false);
            return;
        }

        float walkingShuttlePrice = walkingShuttleFuel.FuelStorage.CalculateFuelPrice(fuelStockMarket);
        float vaclasPrice = vaclasFuel.FuelStorage.CalculateFuelPrice(fuelStockMarket);

        // Assert
        Assert.True(walkingShuttlePrice < vaclasPrice);
    }

    // Fifth Test
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

    // Sixth Test
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