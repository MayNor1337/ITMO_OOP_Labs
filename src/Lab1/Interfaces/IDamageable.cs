using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

public interface IDamageable
{
    public TakeDamageResult TakeDamage(float damage);
}