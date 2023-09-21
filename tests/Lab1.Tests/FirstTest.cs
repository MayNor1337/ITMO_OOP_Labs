using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Systems;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FirstTest
{
    public static IEnumerable<object[]> Data => new List<object[]> { new object[] { ShipCreator.CreatePleasureShuttle() } };

    [Theory]
    [MemberData(nameof(Data))]
    public void T1(Ship shipFirst)
    {
        var sections = new Section[] { new Section(120, EnvironmentType.NebulaeHighDensity, Array.Empty<Obstacle>()) };

        Results result = TrySystem.CheckPassage(shipFirst, sections);

        Assert.True(result == Results.ShipLoss, "ShipLoss");
    }
}