using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;

public interface IShip
{
    public DamageShipResult TakeDamage(float damage);

    public EngineOperationData CalculatingCostsForPath(int length);
}