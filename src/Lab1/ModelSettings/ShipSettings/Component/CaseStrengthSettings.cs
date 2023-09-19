using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.ModelSettings.ShipSettings.Component;

public record CaseStrengthSettings
{
    public static readonly Dictionary<int, float> HealthPoint =
        new Dictionary<int, float>() { { 1, 1 }, { 2, 5 }, { 3, 20 } };
}