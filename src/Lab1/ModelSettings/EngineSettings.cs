using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.ModelSettings;

public static class EngineSettings
{
    public static class ImpulsiveEngineС
    {
        public const float StartFuelPrice = 10f;
        public const float Speed = 5f;
        public const FuelType FuelConsumed = FuelType.ActivePlasma;
        public const float FuelСonsumptionPerSecond = 10f;
        public static readonly EnvironmentType[] WhereCanMove = new[] { EnvironmentType.StandardSpace };
    }

    public static class ImpulsiveEngineE
    {
        public const float StartFuelPrice = 10f;
        public const float Acceleration = 5f;
        public const FuelType FuelConsumed = FuelType.ActivePlasma;
        public const float FuelСonsumptionPerSecond = 10f;

        public static readonly EnvironmentType[] WhereCanMove = new[]
        {
            EnvironmentType.StandardSpace,
            EnvironmentType.NebulaeNitrineParticles
        };
    }

    public static class JumpEngineAlpha
    {
        public const FuelType FuelConsumed = FuelType.GravitonMatter;
        public const float RangeOfTravel = 100f;
        public const float FuelConsumption = 10f;
        public static readonly EnvironmentType[] WhereCanMove = new [] { EnvironmentType.NebulaeHighDensity };
    }


    public static class JumpEngineOmega
    {
        public const FuelType FuelConsumed = FuelType.GravitonMatter;
        public const float RangeOfTravel = 100f;
        public const float FuelConsumption = 10f;
        public static readonly EnvironmentType[] WhereCanMove = new [] { EnvironmentType.NebulaeHighDensity };
    }


    public static class JumpEngineGamma
    {
        public const FuelType FuelConsumed = FuelType.GravitonMatter;
        public const float RangeOfTravel = 100f;
        public const float FuelConsumption = 10f;
        public static readonly EnvironmentType[] WhereCanMove = new [] { EnvironmentType.NebulaeHighDensity };
    }
}