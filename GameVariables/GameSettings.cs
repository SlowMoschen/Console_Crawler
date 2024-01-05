namespace Console_Crawler.GameVariables
{

    // All Game Settings are stored here
    internal class GameSettings
    {
        internal class General
        {
            public static int RestEnduranceRegen { get; } = 10;
            public static int RoundEnduranceRegen { get; } = 7;
            public static int RestHealthRegen { get; } = 5;
            public static int DamageReductionRate { get; } = 100;
            public static int WeaponUpgradeInterval { get; } = 3;
            public static int KickEnduranceCost { get; } = 7;
        }

        internal class EffectDurations
        {
            public static int StrengthPotion { get; } = 4;
            public static int Poison { get; } = 3;
            public static int Burn { get; } = 3;
            public static int Stun { get; } = 1;
        }

        internal class EnemyScaling
        {
            public class ScalingIntervals
            {
                public static int AttackInterval { get; } = 1;
                public static int ArmorInterval { get; } = 1;
                public static int HealthInterval { get; } = 1;
                public static int PoisonInterval { get; } = 1;
                public static int BurnInterval { get; } = 1;
                public static int EXPInterval { get; } = 1;
            }
            public static int AttackScaling { get; } = 15;
            public static int ArmorScaling { get; } = 2;
            public static int HealthScaling { get; } = 20;
            public static int PoisonScaling { get; } = 5;
            public static int BurnScaling { get; } = 5;
            public static int EXPSScaling { get; } = 5;
        }
    }
}