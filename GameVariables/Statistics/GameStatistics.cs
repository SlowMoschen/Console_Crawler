
using Console_Crawler.GameUtilities;

namespace Console_Crawler.GameVariables.Statistics
{
    internal class GameStatistics
    {
        public static string Version { get; } = "1.3.1";
        public static int SurviedRooms { get; set; } = 0;
        public static int SurviedDungeons { get; set; } = 0;
        public static int KilledEnemies { get; set; } = 0;
        public static int TotalEXP { get; set; } = 0;
        public static int TotalGold { get; set; } = 0;
        public static int TotalDamageDealt { get; set; } = 0;
        public static int TotalDamageTaken { get; set; } = 0;
        public static int TotalHealingDone { get; set; } = 0;
        public static int TotalDeaths { get; set; } = 0;
        public static int TotalRests { get; set; } = 0;
        public static int TotalItemsUsed { get; set; } = 0;
        public static int TotalItemsBought { get; set; } = 0;

        public static void SetSavedGameStatistics(SavedGameStats savedGameStats)
        {
            SurviedRooms = savedGameStats.SurviedRooms;
            SurviedDungeons = savedGameStats.SurviedDungeons;
            KilledEnemies = savedGameStats.KilledEnemies;
            TotalEXP = savedGameStats.TotalEXP;
            TotalGold = savedGameStats.TotalGold;
            TotalDamageDealt = savedGameStats.TotalDamageDealt;
            TotalDamageTaken = savedGameStats.TotalDamageTaken;
            TotalHealingDone = savedGameStats.TotalHealingDone;
            TotalDeaths = savedGameStats.TotalDeaths;
            TotalRests = savedGameStats.TotalRests;
            TotalItemsUsed = savedGameStats.TotalItemsUsed;
            TotalItemsBought = savedGameStats.TotalItemsBought;
        }

        public static void ResetGameStatistics()
        {
            SurviedRooms = 0;
            SurviedDungeons = 0;
            KilledEnemies = 0;
            TotalEXP = 0;
            TotalGold = 0;
            TotalDamageDealt = 0;
            TotalDamageTaken = 0;
            TotalHealingDone = 0;
            TotalDeaths = 0;
            TotalRests = 0;
            TotalItemsUsed = 0;
            TotalItemsBought = 0;
        }

        public static void AddSurviedRoom()
        {
            SurviedRooms++;
        }

        public static void AddSurviedDungeon()
        {
            SurviedDungeons++;
        }

        public static void AddKilledEnemy()
        {
            KilledEnemies++;
        }

        public static void AddTotalEXP(int exp)
        {
            TotalEXP += exp;
        }

        public static void AddTotalGold(int gold)
        {
            TotalGold += gold;
        }

        public static void AddTotalDamageDealt(int damage)
        {
            TotalDamageDealt += damage;
        }

        public static void AddTotalDamageTaken(int damage)
        {
            TotalDamageTaken += damage;
        }

        public static void AddTotalHealingDone(int healing)
        {
            TotalHealingDone += healing;
        }

        public static void AddTotalDeath()
        {
            TotalDeaths++;
        }

        public static void AddTotalRest()
        {
            TotalRests++;
        }

        public static void AddTotalItemUsed()
        {
            TotalItemsUsed++;
        }

        public static void AddTotalItemBought()
        {
            TotalItemsBought++;
        }

    }
}
