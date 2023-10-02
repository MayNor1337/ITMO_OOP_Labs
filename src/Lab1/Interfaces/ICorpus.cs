using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

public interface ICorpus
{
    public TakeDamageResult TakeDamage(float damage);
}