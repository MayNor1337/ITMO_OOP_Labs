using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Systems;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FourthTest
{
    [Fact]
    public void T4()
    {
        // Arrange
        Ship pleasureShuttle = ShipCreator.CreatePleasureShuttle();
        Ship vaclas = ShipCreator.CreateVaclas();
        var sections = new Section[] { new Section(30, EnvironmentType.StandardSpace, Array.Empty<Obstacle>()) };
        var pleasureShuttleResultsData = new ResultsData();
        var vaclasResultsData = new ResultsData();

        // Act
        TrySystem.CheckPassage(pleasureShuttle, sections, out pleasureShuttleResultsData);
        TrySystem.CheckPassage(vaclas, sections, out vaclasResultsData);

        if (pleasureShuttleResultsData == null)
            throw new ArgumentNullException(nameof(pleasureShuttleResultsData));
        if (vaclasResultsData == null)
            throw new ArgumentNullException(nameof(vaclasResultsData));

        float pricePleasureShuttle = 0;
        foreach (Fuel data in pleasureShuttleResultsData.Fuel)
        {
            pricePleasureShuttle += data.Amount * FuelExchange.FuelPrice[(int)data.FuelType];
        }

        float priceVaclas = 0;
        foreach (Fuel data in vaclasResultsData.Fuel)
        {
            priceVaclas += data.Amount * FuelExchange.FuelPrice[(int)data.FuelType];
        }

        // Assert
        Assert.True(pricePleasureShuttle < priceVaclas);
    }
}