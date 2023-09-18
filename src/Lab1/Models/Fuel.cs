namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Fuel
{
    private FuelType _fuelType;
    private float _amount;

    public Fuel(FuelType fuelType,  float amount)
    {
        _fuelType = fuelType;
        _amount = amount;
    }
}