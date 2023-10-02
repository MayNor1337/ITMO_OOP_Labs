using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships.Component.Corpuses;

public class MediumCorpus : ICorpus
{
    private float _strengthPoints;
    private float _coefficientDispersion = 0.8f;

    public MediumCorpus()
    {
        _strengthPoints = 3f;
    }

    public TakeDamageResult TakeDamage(float damage)
    {
        _strengthPoints -= damage * _coefficientDispersion;

        if (_strengthPoints < 0)
            return new TakeDamageResult.Broke();

        return new TakeDamageResult.Normal();
    }
}