using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Systems;

public static class TrySystem
{
    public static Results CheckPassage(Ship ship, IEnumerable<Section> sections)
    {
        if (sections == null)
            throw new ArgumentNullException(nameof(sections));

        if (ship == null)
            throw new ArgumentNullException(nameof(ship));

        foreach (Section section in sections)
        {
            Results results = ship.PassageSegment(section, out _);
            if (results == Results.Success)
                continue;

            return results;
        }

        return Results.Success;
    }
}