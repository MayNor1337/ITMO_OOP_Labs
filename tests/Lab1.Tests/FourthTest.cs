using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FourthTest
{
    [Fact]
    public void T4()
    {
        // Arrange
        var walkingShuttle = new WalkingShuttle();
        var vaclas = new Vaclas();
        var standardSpace = new StandardSpace(Array.Empty<ICanExistInStandardSpace>(), 99);
        var path = new Path(new[] { standardSpace });

        // Act
        PassingPathResult walkingShuttleResult = path.LetShip(walkingShuttle);
        PassingPathResult vaclasResults = path.LetShip(vaclas);

        if (walkingShuttleResult is PassingPathResult.Success walkingShuttleFuel == false)
        {
            Assert.True(false);
            return;
        }

        if (vaclasResults is PassingPathResult.Success vaclasFuel == false)
        {
            Assert.True(false);
            return;
        }

        float walkingShuttlePrice = FuelsStockMarket.CostCalculation(walkingShuttleFuel.Fuel);
        float vaclasPrice = FuelsStockMarket.CostCalculation(vaclasFuel.Fuel);

        // Assert
        Assert.True(walkingShuttlePrice < vaclasPrice);
    }
}