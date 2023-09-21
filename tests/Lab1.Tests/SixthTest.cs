using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Systems;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SixthTest
{
    [Fact]
    public void T6()
    {
        // Arrange
        Ship pleasureShuttle = ShipCreator.CreatePleasureShuttle();
        Ship vaclas = ShipCreator.CreateVaclas();
        var sections = new Section[] { new Section(160, EnvironmentType.NebulaeNitrineParticles, Array.Empty<Obstacle>()) };

        // Act
        var pleasureShuttleResultsData = new ResultsData();
        TrySystem.CheckPassage(pleasureShuttle, sections, out pleasureShuttleResultsData);
        var vaclasResultsData = new ResultsData();
        TrySystem.CheckPassage(vaclas, sections, out vaclasResultsData);

        if (pleasureShuttleResultsData == null)
            throw new ArgumentNullException(nameof(pleasureShuttleResultsData));
        if (vaclasResultsData == null)
            throw new ArgumentNullException(nameof(vaclasResultsData));

        // Assert
        Assert.True(pleasureShuttleResultsData.Time > vaclasResultsData.Time);
    }
}