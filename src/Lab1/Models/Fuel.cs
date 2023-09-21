namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Fuel
{
    public Fuel(FuelType fuelType,  float amount)
    {
        FuelType = fuelType;
        Amount = amount;
    }

    public FuelType FuelType { get; }
    public float Amount { get; }
}