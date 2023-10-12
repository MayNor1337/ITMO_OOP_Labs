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

public class ThirdTest
{
    private static FuelStorage voidFuel = new FuelStorage();

    public static IEnumerable<object[]> Vaclas =>
        new List<object[]>
        {
            new object[]
            {
                new Vaclas(new DeflectorFirstRank()),
                new PassingPathResult.DestructionShip(),
            },
        };

    public static IEnumerable<object[]> Avgur =>
        new List<object[]>
        {
            new object[]
            {
                new Avgur(new DeflectorThirdRank()),
                new PassingPathResult.Success(voidFuel, 0),
            },
        };

    public static IEnumerable<object[]> Merediane =>
        new List<object[]>
        {
            new object[]
            {
                new Meredian(new DeflectorSecondRank()),
                new PassingPathResult.Success(voidFuel, 0),
            },
        };

    [Theory]
    [MemberData(nameof(Vaclas))]
    [MemberData(nameof(Avgur))]
    [MemberData(nameof(Merediane))]
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