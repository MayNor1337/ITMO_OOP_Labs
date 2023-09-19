using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.ModelSettings.ShipSettings.Component;

public record DeflectorSettings
{
    public static readonly Dictionary<int, float> HealthPoint =
        new Dictionary<int, float>() { { 0, 0 }, { 1, 10 }, { 2, 20 }, { 3, 30 } };

    public const int PhotonDeflectorCharges = 3;
}