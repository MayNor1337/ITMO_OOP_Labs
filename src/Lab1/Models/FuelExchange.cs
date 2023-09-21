using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public record FuelExchange
{
    public static readonly Dictionary<int, float> FuelPrice = new Dictionary<int, float>()
    {
        { (int)FuelType.ActivePlasma, 10 },
        { (int)FuelType.GravitonMatter, 40 },
    };
}