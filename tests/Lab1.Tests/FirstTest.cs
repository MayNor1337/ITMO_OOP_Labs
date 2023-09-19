using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Systems;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FirstTest
{
    [Fact]
    public void T1()
    {
        Ship shipFirst = ShipCreator.CreateAvgur();
        var sections = new Section[] { new Section(120, EnvironmentType.NebulaeHighDensity, Array.Empty<Obstacle>()) };

        Results result = TrySystem.CheckPassage(shipFirst, sections);

        Assert.True(result == Results.Success, "ShipLoss");
    }
    }