using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Systems;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ThirdTest
{
    public static IEnumerable<object[]> Vaclas =>
        new List<object[]>
        {
            new object[]
            {
                ShipCreator.CreateVaclas(),
                Results.ShipDestruction,
            },
        };

    public static IEnumerable<object[]> Avgur =>
        new List<object[]>
        {
            new object[]
            {
                ShipCreator.CreateAvgur(),
                Results.Success,
            },
        };

    public static IEnumerable<object[]> Merediane =>
        new List<object[]>
        {
            new object[]
            {
                ShipCreator.CreateMerediane(),
                Results.Success,
            },
        };

    [Theory]
    [MemberData(nameof(Vaclas))]
    [MemberData(nameof(Avgur))]
    [MemberData(nameof(Merediane))]
    public void T3(Ship ship, Results referenceResult)
    {
        // Arrange
        var sections = new Section[] { new Section(30, EnvironmentType.NebulaeNitrineParticles, new Obstacle[] { new CosmoWhale() }) };

        // Act
        Results result = TrySystem.CheckPassage(ship, sections, out _);

        // Assert
        Assert.True(result == referenceResult);
    }
}