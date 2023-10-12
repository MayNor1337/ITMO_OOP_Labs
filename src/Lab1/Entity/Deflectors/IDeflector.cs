using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;

public interface IDeflector
{
    public TakeDamageResult TakeDamage(float damage);
}