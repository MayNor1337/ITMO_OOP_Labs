using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Corpuses;

public interface ICorpus
{
    TakeDamageResult TakeDamage(float damage);
}