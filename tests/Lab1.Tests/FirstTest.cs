using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FirstTest
{
    public static IEnumerable<object[]> WalkingShuttle =>
        new List<object[]>
        {
            new object[]
            {
            new WalkingShuttle(),
            },
        };

    public static IEnumerable<object[]> Avgur =>
        new List<object[]>
            {
                new object[]
                {
                    new Avgur(),
                },
            };

    [Theory]
    [MemberData(nameof(WalkingShuttle))]
    [MemberData(nameof(Avgur))]
    public void IShip_LetShip_ShipsWillNotBeAbleToFly(IShip ship)
    {
        // Arrange
        var nebulaeHighDensity = new NebulaeHighDensity(Array.Empty<ICanExistInNebulaeHighDensity>(), 120);
        var path = new Path(new[] { nebulaeHighDensity });

        // Act
        PassingPathResult result = path.LetShip(ship);

        // Assert
        Assert.True(result is PassingPathResult.Impossible);
    }
}