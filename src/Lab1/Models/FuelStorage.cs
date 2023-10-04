using System;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class FuelStorage
{
    public FuelStorage() { }

    public float AmountActivePlasma { get; private set; }
    public float AmountGravitonMatter { get; private set; }

    public void AddFuel(IFuel fuel)
    {
        if (fuel.Amount < 0)
            throw new ArgumentException("Value cannot be negative", nameof(fuel));

        if (fuel is ActivePlasma activePlasma)
        {
            AmountActivePlasma += activePlasma.Amount;
            return;
        }

        if (fuel is GravitonMatter gravitonMatter)
        {
            AmountGravitonMatter += gravitonMatter.Amount;
            return;
        }

        throw new ArgumentException("Fuel type is uncertain", nameof(fuel));
    }
}