using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SecondTest
{
    public static IEnumerable<object[]> Avgur =>
        new List<object[]>
        {
            new object[]
            {
                new Avgur(),
                new PassingPathResult.CrewDeath(),
            },
        };

    public static IEnumerable<object[]> AvgurWithPhotonDeflector =>
        new List<object[]>
        {
            new object[]
            {
                new Avgur(true),
                new PassingPathResult.Success(),
            },
        };

    [Theory]
    [MemberData(nameof(Avgur))]
    [MemberData(nameof(AvgurWithPhotonDeflector))]
    public void T2(IShip ship, PassingPathResult referenceResult)
    {
        // Arrange
        var standardSpace = new NebulaeHighDensity(new[] { new AntimatterFlares() });
        var path = new Path(new[] { standardSpace });

        // Act
        PassingPathResult result = path.LetShip(ship);

        // Assert
        Assert.True(result.GetType() == referenceResult.GetType());
    }
}