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

public class FourthTest
{
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
}