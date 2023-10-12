using Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;

public interface IShipWithDeflector : IShip
{
    public IDeflector Deflector { get; }
}