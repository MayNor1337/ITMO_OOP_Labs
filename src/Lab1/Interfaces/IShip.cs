using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

public interface IShip
{
    public DamageShipResult TakePhysicalDamage(float damage);

    public DamageShipResult TakeRadiationDamage(float damage);
}