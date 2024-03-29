﻿namespace Console_Crawler.GameVariables.Statistics.PlayerStatistics
{
    internal class LevelUpModifers
    {
        public static int Attack { get; } = 5;
        public static int Armor { get; } = 3;
        public static int MaxHealth { get; } = 100;
        public static int EXPRating { get; } = 100;
    }
    internal class PlayerStats
    {
        public static string Name { get; set; } = "Player";
        public static int InitialAttack { get; set; } = 10;
        public static double InitialStrength { get; set; } = 1.0;
        public static int InitialArmor { get; set; } = 10;
        public static int InitialHealth { get; set; } = 100;
        public static int InitialMaxHealth { get; set; } = 100;
        public static int EXP { get; set; } = 0;
        public static int EXPToNextLevel { get; set; } = 100;
        
        // Is used to Calculate Enemy and Weapon stats
        public static int Level { get; set; } = 1;
        public static int MaxLevel { get; set; } = 30;

        public static void ResetPlayerStats()
        {
            Name = "Player";
            InitialAttack = 10;
            InitialStrength = 1.0;
            InitialArmor = 10;
            InitialHealth = 100;
            InitialMaxHealth = 100;
            EXP = 0;
            EXPToNextLevel = 100;
            Level = 1;
            MaxLevel = 30;
        }
    }
}
