using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.ModelSettings.EngineSettings;

public record ImpulsiveEngineСSettings
{
    public static readonly EnvironmentType[] WhereCanMove = new[] { EnvironmentType.StandardSpace };

    public const float StartFuelPrice = 10f;
    public const float Speed = 5f;
    public const FuelType FuelConsumed = FuelType.ActivePlasma;
    public const float FuelСonsumptionPerSecond = 10f;
}