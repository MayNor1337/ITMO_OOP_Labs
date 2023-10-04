using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FifthTest
{
    [Fact]
    public void T5()
    {
        // Arrange
        var avgur = new Avgur();
        var stella = new Stella();
        var standardSpace = new NebulaeHighDensity(Array.Empty<ICanExistInNebulaeHighDensity>(), 80);
        var path = new Path(new[] { standardSpace });

        // Act
        PassingPathResult avgurResults = path.LetShip(avgur);
        PassingPathResult stellaResults = path.LetShip(stella);

        // Assert
        Assert.True(avgurResults is PassingPathResult.Success && stellaResults is PassingPathResult.Success);
    }
}