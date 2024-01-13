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
            Console.WriteLine();
            player.PrintCoreStats();
            DisplayLevelProgressBar(player.Level, player.EXP, player.EXPToNextLevel);
            return DisplayOptionsMenu("What would you like to do?", MenuOptions.MainMenuOptions);
        }

        public static void DisplayAllShops(Player player)
        {
            while (GameBools.IsInShop)
            {
                Console.Clear();
                DisplayHeader("Shopping District");
                string shopChoice = DisplayOptionsMenu("What would you like to do?", MenuOptions.ShopMenues.AllShops);

                switch (shopChoice)
                {
                    case "Talia's Potion Shop":
                        DisplayShopMenu(player, shopChoice);
                        break;
                    case "Galen's Renewal Resavoir":
                        DisplayRenewalResavoir(player, shopChoice);
                        break;
                    case "Leave Shopping District":
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
                Console.WriteLine(" Player:");
                Console.WriteLine();
                player.PrintCoreStats();
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

                string statsMenuChoice = DisplayOptionsMenu("What would you like to do?", MenuOptions.StatsMenuOptions);

                // The Stats Menu shows the chosen Players Name, so we have to change it back to the original so the switch statement works
                statsMenuChoice = statsMenuChoice == $"{PlayerStats.Name} Statistics" ? "Player Stats" : statsMenuChoice;

                switch (statsMenuChoice)
                {
                    case "Player Stats":
                        DisplayPlayerStats(player);
                        break;
                    case "Game Statistics":
                        DisplayGameStats();
                        break;
                    case "Exit Stats":
                        GameBools.IsInStatsMenu = false;
                        GameBools.IsInMenu = true;
                        break;
                }
            }
        }

        public static void DisplayGameInfosMenu()
        {
            while (GameBools.IsInTutorial)
            {
                Console.Clear();
                DisplayHeader("Game Infos");
                
                string gameInfosMenuChoice = DisplayOptionsMenu("What do you want to know more about?", MenuOptions.GameInfosMenuOptions);

                switch (gameInfosMenuChoice)
                {
                    case "Gameplay":
                        DisplayGameplayInfos();
                        break;
                    case "Battle":
                        DisplayBattleInfos();
                        break;
                    case "Shopping District":
                        DisplayShoppingDistrictInfos();
                        break;
                    case "Items":
                        DisplayItemInfos();
                        break;
                    case "Weapons":
                        DisplayWeaponInfos();
                        break;
                    case "Enemies":
                        DisplayEnemyInfos();
                        break;
                    case "Credits":
                        DisplayCredits();
                        break;
                        case "All":
                        DisplayAllGameInfos();
                        break;
                    case "Exit Game Infos":
                        GameBools.IsInTutorial = false;
                        GameBools.IsInMenu = true;
                        break;
                }
            }
        }
    }
}
