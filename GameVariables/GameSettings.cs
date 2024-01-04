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
    }
}