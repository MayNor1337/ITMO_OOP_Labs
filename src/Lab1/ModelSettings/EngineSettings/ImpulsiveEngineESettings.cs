using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.ModelSettings.EngineSettings;

public record ImpulsiveEngineESettings
{
    public const float StartFuelPrice = 10f;
    public const float Acceleration = 5f;
    public const FuelType FuelConsumed = FuelType.ActivePlasma;
    public const float FuelСonsumptionPerSecond = 10f;

    public static readonly EnvironmentType[] WhereCanMove = new[]
    {
        EnvironmentType.StandardSpace,
    };
}