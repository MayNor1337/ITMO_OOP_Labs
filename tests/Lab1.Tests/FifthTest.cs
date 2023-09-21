using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Systems;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FifthTest
{
    [Fact]
    public void T5()
    {
        // Arrange
        Ship avgur = ShipCreator.CreateAvgur();
        Ship stella = ShipCreator.CreateStella();
        var sections = new Section[] { new Section(80, EnvironmentType.NebulaeHighDensity, Array.Empty<Obstacle>()) };

        // Act
        Results avgurResults = TrySystem.CheckPassage(avgur, sections, out _);
        Results stellaResults = TrySystem.CheckPassage(avgur, sections, out _);

        // Assert
        Assert.True(avgurResults == Results.Success && stellaResults == Results.Success);
    }
}