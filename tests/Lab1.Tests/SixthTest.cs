using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SixthTest
{
    [Fact]
    public void T6()
    {
        // Arrange
        var walkingShuttle = new WalkingShuttle();
        var vaclas = new Vaclas();

        var nebulaeNitrine = new NebulaeNitrineParticles(Array.Empty<ICanExistInNebulaeNitrineParticles>(), 160);
        var path = new Path(new[] { nebulaeNitrine });

        // Act
        PassingPathResult walkingShuttleResult = path.LetShip(walkingShuttle);
        PassingPathResult vaclasResult = path.LetShip(vaclas);

        // Assert
        Assert.True(walkingShuttleResult is PassingPathResult.Impossible && vaclasResult is PassingPathResult.Success);
    }
}