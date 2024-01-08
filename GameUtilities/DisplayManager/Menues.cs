
using Console_Crawler.GameCharacters;
using Console_Crawler.GameVariables;
using Console_Crawler.GameVariables.Statistics.PlayerStatistics;

namespace Console_Crawler.GameUtilities.DisplayManager
{
    internal partial class DisplayManager
    {
        public static string DisplayMainMenu(Player player)
        {
            Console.Clear();
            DisplayHeader("Main Menu");
            DisplayLevelProgressBar(player.Level, player.EXP, player.EXPToNextLevel);
            return DisplayOptionsMenu("What would you like to do?", MenuOptions.MainMenuOptions);
        }

        public static void DisplayShopMenu(Player player)
        {
            while (GameBools.IsInShop)
            {
                Console.Clear();
                DisplayHeader("Shop");
                string shopMenuChoice = DisplayOptionsMenu("What would you like to do?", MenuOptions.ShopMenuOptions);

                switch (shopMenuChoice)
                {
                    case "Buy":
                         
                        if(player.Inventory.Gold < 0)
                        {
                            Console.WriteLine(" You don't have enough gold to buy anything.");
                        }

                        DisplayBuyingShop(player);
                        break;
                    case "Exit Shop":
                        GameBools.IsInShop = false;
                        GameBools.IsInMenu = true;
                        break;
                }
            }
        }

        public static void DisplayInventoryMenu(Player player)
        {
            while (GameBools.IsInInventory)
            {
                Console.Clear();
                DisplayHeader("Inventory");
                DisplayCurrentInventory(player);
                string inventoryMenuChoice = DisplayOptionsMenu("What would you like to do?", MenuOptions.InventoryMenuOptions);

                switch (inventoryMenuChoice)
                {
                    case "Use Item":
                        DisplayUsingInventory(player);
                        break;
                    case "Exit Inventory":
                        GameBools.IsInInventory = false;
                        GameBools.IsInMenu = true;
                        break;
                }
            }
        }

        public static void DisplayStatsMenu(Player player)
        {
            while (GameBools.IsInStatsMenu)
            {
                Console.Clear();
                DisplayHeader("Stats");
                player.PrintStats();
                string statsMenuChoice = DisplayOptionsMenu("What would you like to do?", MenuOptions.StatsMenuOptions);

                // The Stats Menu shows the chosen Players Name, so we have to change it back to the original so the switch statement works
                statsMenuChoice = statsMenuChoice == $"{PlayerStats.Name} Statistics" ? "Player Stats" : statsMenuChoice;

                switch (statsMenuChoice)
                {
                    case "Player Stats":
                        DisplayPlayerStats(player);
                        break;
                    case "Exit Stats":
                        GameBools.IsInStatsMenu = false;
                        GameBools.IsInMenu = true;
                        break;
                }
            }
        }
    }
}
