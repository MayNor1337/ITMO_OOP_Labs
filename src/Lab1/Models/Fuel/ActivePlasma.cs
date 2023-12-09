namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

public class ActivePlasma : IFuel
{
    public ActivePlasma(float amount)
    {
        Amount = amount;
    }

    public float Amount { get; }
}