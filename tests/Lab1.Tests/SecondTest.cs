using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
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
                new Vaclas(),
                new PassingPathResult.CrewDeath(),
            },
        };

    public static IEnumerable<object[]> VaclasWithPhotonDeflector =>
        new List<object[]>
        {
            new object[]
            {
                new Vaclas(true),
                new PassingPathResult.Success(voidFuel),
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
            result = new PassingPathResult.Success(voidFuel);

        // Assert
        Assert.True(result == referenceResult);
    }
}