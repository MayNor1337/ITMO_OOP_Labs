using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

public class FuelStockMarket : IFuelStockMarket
{
    private float _priceForGraviton = 10;
    private float _priceForActivePlasma = 30;

    public float CostCalculation(IFuel fuel)
    {
        if (fuel is GravitonMatter)
            return _priceForGraviton * fuel.Amount;
        if (fuel is ActivePlasma)
            return _priceForActivePlasma * fuel.Amount;

        throw new ArgumentException("Fuel type is uncertain", nameof(fuel));
    }
}