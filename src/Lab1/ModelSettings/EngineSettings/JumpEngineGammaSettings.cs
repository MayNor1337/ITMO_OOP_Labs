using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.ModelSettings.EngineSettings;

public record JumpEngineGammaSettings
{
    public const FuelType FuelConsumed = FuelType.GravitonMatter;
    public const float RangeOfTravel = 100f;
    public const float FuelConsumption = 10f;
    public static readonly EnvironmentType[] WhereCanMove = new[] { EnvironmentType.NebulaeHighDensity };
}