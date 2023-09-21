﻿using System;
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
    public static IEnumerable<object[]> PleasureShuttle =>
        new List<object[]>
        {
            new object[]
            {
            ShipCreator.CreatePleasureShuttle(),
            Results.ShipLoss,
            },
        };

    public static IEnumerable<object[]> Avgur =>
        new List<object[]>
            {
                new object[]
                {
                    ShipCreator.CreateAvgur(),
                    Results.ShipLoss,
                },
            };

    public static IEnumerable<object[]> Vaclas =>
        new List<object[]>
            { new object[] { ShipCreator.CreateVaclas() } };

    public static IEnumerable<object[]> Merediane =>
        new List<object[]>
            { new object[] { ShipCreator.CreateMerediane() } };

    [Theory]
    [MemberData(nameof(PleasureShuttle))]
    [MemberData(nameof(Avgur))]
    public void T1(Ship ship, Results referenceResult)
    {
        // Arrange
        var sections = new Section[] { new Section(120, EnvironmentType.NebulaeHighDensity, Array.Empty<Obstacle>()) };

        // Act
        Results result = TrySystem.CheckPassage(ship, sections, out _);

        // Assert
        Assert.True(result == referenceResult);
    }
}