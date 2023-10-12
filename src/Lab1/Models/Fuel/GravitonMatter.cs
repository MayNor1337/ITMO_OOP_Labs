namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

public class GravitonMatter : IFuel
{
    public GravitonMatter(float amount)
    {
        Amount = amount;
    }

    public float Amount { get; }
}