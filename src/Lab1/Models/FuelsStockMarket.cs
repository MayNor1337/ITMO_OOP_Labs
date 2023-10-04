namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public static class FuelsStockMarket
{
    private static float _priceForGraviton = 10;
    private static float _priceForActivePlasma = 30;

    public static float CostCalculation(FuelStorage fuelStorage)
    {
        return (fuelStorage.AmountActivePlasma * _priceForActivePlasma) +
               (fuelStorage.AmountGravitonMatter * _priceForGraviton);
    }
}