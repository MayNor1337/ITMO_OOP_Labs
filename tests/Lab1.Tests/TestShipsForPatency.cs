using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class TestShipsForPatency
{
    // General data
    private static FuelStorage voidFuel = new FuelStorage();

    // Firs test
    public static IEnumerable<object[]> WalkingShuttle1 =>
        new List<object[]>
        {
            new object[]
            {
                new WalkingShuttle(),
            },
        };

    public static IEnumerable<object[]> Avgur1 =>
        new List<object[]>
        {
            new object[]
            {
                new Avgur(new DeflectorFirstRank()),
            },
        };

    // Second test
    public static IEnumerable<object[]> Vaclas2 =>
        new List<object[]>
        {
            new object[]
            {
                new Vaclas(new DeflectorFirstRank()),
                new PassingPathResult.CrewDeath(),
            },
        };

    public static IEnumerable<object[]> VaclasWithPhotonDeflector2 =>
        new List<object[]>
        {
            new object[]
            {
                new Vaclas(new DeflectorWithPhoton(new DeflectorFirstRank())),
                new PassingPathResult.Success(voidFuel, 0),
            },
        };

    // Third Test
    public static IEnumerable<object[]> Vaclas3 =>
        new List<object[]>
        {
            new object[]
            {
                new Vaclas(new DeflectorFirstRank()),
                new PassingPathResult.DestructionShip(),
            },
        };

    public static IEnumerable<object[]> Avgur3 =>
        new List<object[]>
        {
            new object[]
            {
                new Avgur(new DeflectorThirdRank()),
                new PassingPathResult.Success(voidFuel, 0),
            },
        };

    public static IEnumerable<object[]> Merediane3 =>
        new List<object[]>
        {
            new object[]
            {
                new Meredian(new DeflectorSecondRank()),
                new PassingPathResult.Success(voidFuel, 0),
            },
        };

    [Theory]
    [MemberData(nameof(WalkingShuttle1))]
    [MemberData(nameof(Avgur1))]
    public void IShip_LetShip_ShipsWillNotBeAbleToFly(IShip ship)
    {
        // Arrange
        var nebulaeHighDensity = new NebulaeHighDensity(Array.Empty<INebulaeHighDensityObstacle>(), 120);
        var path = new Path(new[] { nebulaeHighDensity });

        // Act
        PassingPathResult result = path.LetShip(ship);

        // Assert
        Assert.True(result is PassingPathResult.Impossible);
    }

    [Theory]
    [MemberData(nameof(Vaclas2))]
    [MemberData(nameof(VaclasWithPhotonDeflector2))]
    public void IShip_LetShip_ShipsFlyInNebulaeHighDensityOneOfThemSurvives(IShip ship, PassingPathResult referenceResult)
    {
        // Arrange
        var nebulaeHighDensity = new NebulaeHighDensity(new[] { new AntimatterFlares() }, 99);
        var path = new Path(new[] { nebulaeHighDensity });

        // Act
        PassingPathResult result = path.LetShip(ship);

        if (result is PassingPathResult.Success)
            result = new PassingPathResult.Success(voidFuel, 0);

        // Assert
        Assert.True(result == referenceResult);
    }

    [Theory]
    [MemberData(nameof(Vaclas3))]
    [MemberData(nameof(Avgur3))]
    [MemberData(nameof(Merediane3))]
    public void IShip_LetShip_ShipsCollideWithCosmoWhales(IShip ship, PassingPathResult referenceResult)
    {
        // Arrange
        var standardSpace = new NebulaeNitrineParticles(new[] { new CosmoWhale() }, 99);
        var path = new Path(new[] { standardSpace });

        // Act
        PassingPathResult result = path.LetShip(ship);
        if (result is PassingPathResult.Success)
            result = new PassingPathResult.Success(voidFuel, 0);

        // Assert
        Assert.True(result == referenceResult);
    }
}