using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

public class FuelStorage
{
    private List<IFuel> fuels = new List<IFuel>();
    public FuelStorage() { }

    public void AddFuel(IFuel fuel)
    {
        if (fuel.Amount < 0)
            throw new ArgumentException("Value cannot be negative", nameof(fuel));

        fuels.Add(fuel);
    }

    public float CalculateFuelPrice(IFuelStockMarket fuelStockMarket)
    {
        float price = 0;
        foreach (IFuel fuel in fuels)
        {
            price += fuelStockMarket.CostCalculation(fuel);
        }

        return price;
    }
}