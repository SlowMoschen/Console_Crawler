using Console_Crawler.GameCharacters;
using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.GameVariables.Statistics.PlayerStatistics;

namespace Console_Crawler.GameUtilities.DisplayManager
{
    internal partial class DisplayManager
    {
        public static void DisplayPlayerStats(Player player)
        {
            Console.Clear();
            DisplayHeader($"{PlayerStats.Name} Stats");
            player.PrintStats();
            WaitForInput();
        }

        public static void DisplayGameStats()
        {
            Console.Clear();
            DisplayHeader("Game Stats");
            DisplayGameStatistics();
        }

        private static void DisplayGameStatistics()
        {
            Console.Clear();
            DisplayHeader("Game Statistics");
            Console.WriteLine();
            Console.WriteLine($" Total Deaths: {GameStatistics.TotalDeaths}");
            Console.WriteLine();
            Console.WriteLine($" Total Dungeon survied: {GameStatistics.SurviedDungeons}");
            Console.WriteLine($" Total Room survied: {GameStatistics.SurviedRooms}");
            Console.WriteLine($" Total Enemies killed: {GameStatistics.KilledEnemies}");
            Console.WriteLine();
            Console.WriteLine($" Total Damage dealt: {GameStatistics.TotalDamageDealt}");
            Console.WriteLine($" Total Damage taken: {GameStatistics.TotalDamageTaken}");
            Console.WriteLine();
            Console.WriteLine($" Total EXP gained: {GameStatistics.TotalEXP}");
            Console.WriteLine($" Total Gold gained: {GameStatistics.TotalGold}");
            Console.WriteLine();
            Console.WriteLine($" Total Rests: {GameStatistics.TotalRests}");
            Console.WriteLine($" Total Healing done: {GameStatistics.TotalHealingDone}");
            Console.WriteLine();
            Console.WriteLine($" Total Items used: {GameStatistics.TotalItemsUsed}");
            Console.WriteLine($" Total Items bought: {GameStatistics.TotalItemsBought}");
            WaitForInput();

        }

    }
}
