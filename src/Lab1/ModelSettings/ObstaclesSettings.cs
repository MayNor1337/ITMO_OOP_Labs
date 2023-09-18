namespace Itmo.ObjectOrientedProgramming.Lab1.ModelSettings
{
    public static class ObstaclesSettings
    {
        public static class Meteorite
        {
            public static float Damage { get; } = 4f;
            public static int CollisionsAmount { get; } = 1;
        }

        public static class SmallAsteroid
        {
            public const float Damage = 1f;
            public const int CollisionsAmount = 1;
        }

        public static class AntimatterFlares
        {
            public const float Damage = 0;
            public const int CollisionsAmount = 1;
        }

        public static class CosmoWhale
        {
            public const float Damage = 40;
            public const int CollisionsAmount = 1;
        }
    }
}