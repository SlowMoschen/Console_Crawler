using Console_Crawler.GameCharacters;
using Console_Crawler.GameVariables.Statistics;
using Newtonsoft.Json;

namespace Console_Crawler.GameUtilities
{
    internal class SaveGame
    {
        public Player Player { get; set; }
        public SavedGameStats GameStatistics { get; set; }

        public SaveGame(Player player)
        {
            Player = player;
            GameStatistics = new SavedGameStats();
        }
    }


    // This class is used to save the game statistics to a file - it is not used in the game
    // WHY: It is a workaround for the fact that the GameStatistics class is static
    //      and therefore cannot be serialized  
    internal class SavedGameStats
    {
        public int SurviedRooms { get; set; }
        public int SurviedDungeons { get; set; }
        public int KilledEnemies { get; set; }
        public int TotalEXP { get; set; }
        public int TotalGold { get; set; }
        public int TotalDamageDealt { get; set; }
        public int TotalDamageTaken { get; set; }
        public int TotalHealingDone { get; set; }
        public int TotalDeaths { get; set; }
        public int TotalRests { get; set; }
        public int TotalItemsUsed { get; set; }
        public int TotalItemsBought { get; set; }

        public SavedGameStats()
        {
            SurviedRooms = GameStatistics.SurviedRooms;
            SurviedDungeons = GameStatistics.SurviedDungeons;
            KilledEnemies = GameStatistics.KilledEnemies;
            TotalEXP = GameStatistics.TotalEXP;
            TotalGold = GameStatistics.TotalGold;
            TotalDamageDealt = GameStatistics.TotalDamageDealt;
            TotalDamageTaken = GameStatistics.TotalDamageTaken;
            TotalHealingDone = GameStatistics.TotalHealingDone;
            TotalDeaths = GameStatistics.TotalDeaths;
            TotalRests = GameStatistics.TotalRests;
            TotalItemsUsed = GameStatistics.TotalItemsUsed;
            TotalItemsBought = GameStatistics.TotalItemsBought;
        }
    }

    internal class SaveGameManager
    {
        private static string executablePath = AppDomain.CurrentDomain.BaseDirectory;
        private static string saveGamePath = Path.Combine(executablePath, "SaveGame.json");

        public static bool SaveGameToFile(Player player)
        {
            try {
                
                SaveGame saveGame = new SaveGame(player);

                if (File.Exists(saveGamePath))
                {
                    File.Delete(saveGamePath);
                }

                File.Create(saveGamePath).Close();

                string json = JsonConvert.SerializeObject(saveGame, Formatting.Indented);

                File.WriteAllText(saveGamePath, json);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static SaveGame LoadGameFromFile()
        {
            try
            {
                if(File.Exists(saveGamePath))
                {
                    string json = File.ReadAllText(saveGamePath);

                    SaveGame saveGame = JsonConvert.DeserializeObject<SaveGame>(json);

                    return saveGame;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool DeleteSaveGame()
        {
            try
            {
                if (File.Exists(saveGamePath))
                {
                    File.Delete(saveGamePath);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        
    }
}
