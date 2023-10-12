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

public class SecondTest
{
    private static FuelStorage voidFuel = new FuelStorage();

    public static IEnumerable<object[]> Vaclas =>
        new List<object[]>
        {
            new object[]
            {
                new Vaclas(new DeflectorFirstRank()),
                new PassingPathResult.CrewDeath(),
            },
        };

    public static IEnumerable<object[]> VaclasWithPhotonDeflector =>
        new List<object[]>
        {
            new object[]
            {
                new Vaclas(new DeflectorWithPhoton(new DeflectorFirstRank())),
                new PassingPathResult.Success(voidFuel, 0),
            },
        };

    [Theory]
    [MemberData(nameof(Vaclas))]
    [MemberData(nameof(VaclasWithPhotonDeflector))]
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
}