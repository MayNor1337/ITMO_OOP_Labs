using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class ActivePlasma : IFuel
{
    public ActivePlasma(float amount)
    {
        Amount = amount;
    }

    public float Amount { get; }
}