using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Route;

public class Path
{
    private IEnviroment[] _enviroments;

    public Path(IEnumerable<IEnviroment> enviroments)
    {
        _enviroments = enviroments.ToArray();
    }

    public PassingPathResult LetShip(IShip ship)
    {
        var fuelStorage = new FuelStorage();
        float time = 0f;
        foreach (IEnviroment enviroment in _enviroments)
        {
            PassageResult result = enviroment.CalculationPassage(ship);

            if (result is PassageResult.Success success)
            {
                fuelStorage.AddFuel(success.Fuel);
                time += success.Time;
                continue;
            }

            if (result is PassageResult.Impossible)
                return new PassingPathResult.Impossible();

            if (result is PassageResult.CrewDied)
                return new PassingPathResult.CrewDeath();

            if (result is PassageResult.ShipDestroyed)
                return new PassingPathResult.DestructionShip();
        }

        return new PassingPathResult.Success(fuelStorage, time);
    }
}