using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships.Component;
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
            new PassingPathResult.ShipLoss(),
            },
        };

    public static IEnumerable<object[]> Avgur =>
        new List<object[]>
            {
                new object[]
                {
                    new Avgur(),
                    new PassingPathResult.ShipLoss(),
                },
            };

    [Theory]
    [MemberData(nameof(WalkingShuttle))]
    [MemberData(nameof(Avgur))]
    public void T1(IShip ship, PassingPathResult referenceResult)
    {
        // Arrange
        var standardSpace = new StandardSpace(Array.Empty<ICanExistInStandardSpace>());
        var path = new Path(new[] { standardSpace });

        // Act
        PassingPathResult result = path.LetShip(ship);

        // Assert
        Assert.True(result.GetType() == referenceResult.GetType());
    }
}