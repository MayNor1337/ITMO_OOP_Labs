using Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

public class AntimatterFlares : INebulaeHighDensityObstacle
{
    public AntimatterFlares() { }

    public DamageShipResult CollideTo(IShip ship)
    {
        if (ship is not IShipWithDeflector shipWithDeflector
            || shipWithDeflector.Deflector is not DeflectorWithPhoton deflectorWithPhoton)
            return new DamageShipResult.CrewDied();

        TakeDamageResult result = deflectorWithPhoton.ReflectRadiation();
        if (result is TakeDamageResult.Broken)
            return new DamageShipResult.CrewDied();

        return new DamageShipResult.Survived();
    }
}