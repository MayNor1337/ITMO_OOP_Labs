using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Systems;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SecondTest
{
    public static IEnumerable<object[]> Avgur =>
        new List<object[]>
        {
            new object[]
            {
                ShipCreator.CreateAvgur(),
                Results.CrewDeath,
            },
        };

    public static IEnumerable<object[]> AvgurWithPhotonDeflector =>
        new List<object[]>
        {
            new object[]
            {
                ShipCreator.CreateAvgur(true),
                Results.Success,
            },
        };

    [Theory]
    [MemberData(nameof(Avgur))]
    [MemberData(nameof(AvgurWithPhotonDeflector))]
    public void T2(Ship ship, Results referenceResult)
    {
        // Arrange
        var sections = new Section[] { new Section(30, EnvironmentType.NebulaeHighDensity, new Obstacle[] { new AntimatterFlares() }) };

        // Act
        Results result = TrySystem.CheckPassage(ship, sections, out _);

        // Assert
        Assert.True(result == referenceResult);
    }
}