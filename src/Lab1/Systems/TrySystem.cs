using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Systems;

public static class TrySystem
{
    public static Results CheckPassage(Ship ship, IEnumerable<Section> sections, out ResultsData? resultsData)
    {
        if (sections == null)
            throw new ArgumentNullException(nameof(sections));

        if (ship == null)
            throw new ArgumentNullException(nameof(ship));

        resultsData = new ResultsData();

        foreach (Section section in sections)
        {
            Results results = ship.PassageSegment(section, out Fuel? newFuel, out float time);
            if (results == Results.Success)
            {
                if (newFuel != null)
                    resultsData.AddFuel(newFuel);
                resultsData.Time += time;
                continue;
            }

            resultsData = null;
            return results;
        }

        return Results.Success;
    }
}