using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships.Component;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;

public class Ship : IPassingSegment
{
    private readonly IEngine[] _engines;
    private readonly Deflector _deflector;
    private readonly CaseStrength _case;
    private readonly bool _haveAntiNetrinEmmiter;

    public Ship(IEnumerable<IEngine> engines, Deflector deflector, CaseStrength corpus, bool antiNetrinEmmiter)
    {
        _engines = Enumerable.ToArray(engines);
        _deflector = deflector;
        _case = corpus;
        _haveAntiNetrinEmmiter = antiNetrinEmmiter;
    }

    public Results PassageSegment(Section section, out Fuel? fuel, out float time)
    {
        if (section == null)
            throw new ArgumentNullException(nameof(section));

        Results intermediateResults = CheckingCollisions(section);

        if (intermediateResults != Results.Success)
        {
            time = 0;
            fuel = null;
            return intermediateResults;
        }

        return ChekingFlyOpportunity(section, out fuel, out time);
    }

    private Results CheckingCollisions(Section section)
    {
        int i;
        Obstacle[] obstacles = section.GetObstacles();
        for (i = 0; i < obstacles.Length; i++)
        {
            if (obstacles[i] is CosmoWhale && _haveAntiNetrinEmmiter)
                continue;

            float overDamage;
            if (_deflector.StrengthCheck(obstacles[i], out overDamage))
                continue;

            if (overDamage != 0 && _case.CheckOverDamage(overDamage))
                continue;

            if (_case.StrengthCheck(obstacles[i], out _))
                continue;

            if (obstacles[i] is AntimatterFlares)
                return Results.CrewDeath;

            return Results.ShipDestruction;
        }

        return Results.Success;
    }

    private Results ChekingFlyOpportunity(Section section, out Fuel? fuel, out float time)
    {
        foreach (IEngine engine in _engines)
        {
            if (engine.TryPassTrack(section.Type, section.Length, out fuel, out time))
            {
                return Results.Success;
            }
        }

        time = 0;
        fuel = null;
        return Results.ShipLoss;
    }
}
