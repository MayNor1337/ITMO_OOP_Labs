using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class GravitonMatter : IFuel
{
    public GravitonMatter(float amount)
    {
        Amount = amount;
    }

    public float Amount { get; }
}