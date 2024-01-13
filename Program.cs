using Console_Crawler.GameCharacters;
using Console_Crawler.GameUtilities;
using Console_Crawler.GameUtilities.DisplayManager;
using Console_Crawler.GameVariables;
using Console_Crawler.GameVariables.Statistics;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        RunDotNetCommand("run");

        // Initialize the game
        Player player;

        SaveGame saveGame = SaveGameManager.LoadGameFromFile();

        if(saveGame != null)
        {
            DisplayManager.DisplayLoadSuccess();
            player = saveGame.Player;
            GameStatistics.SetSavedGameStatistics(saveGame.GameStatistics);
            DisplayManager.GreetPlayerBack(player);
        }
        else
        {
            player = DisplayManager.InitializePlayerFromPreGameMenu();
        }

        GameBools.IsGameRunning = true;
        GameBools.IsInMenu = true;

        while (GameBools.IsInMenu)
        {
            if(GameBools.IsDead)
            {
                player.Revive();
            }

            string menuChoice = DisplayManager.DisplayMainMenu(player);

            switch (menuChoice)
            {
                case "Enter Dungeon":
                    GameBools.IsInMenu = false;
                    GameBools.IsInBattle = true;
                    DisplayManager.StartDungeon(player);
                    break;
                case "Shopping District":
                    GameBools.IsInMenu = false;
                    GameBools.IsInShop = true;
                    DisplayManager.DisplayAllShops(player);
                    break;
                case "Inventory":
                    GameBools.IsInMenu = false;
                    GameBools.IsInInventory = true;
                    DisplayManager.DisplayInventoryMenu(player);
                    break;
                case "Stats":
                    GameBools.IsInMenu = false;
                    GameBools.IsInStatsMenu = true;
                    DisplayManager.DisplayStatsMenu(player);
                    break;
                case "Game Infos":
                    GameBools.IsInMenu = false;
                    GameBools.IsInTutorial = true;
                    DisplayManager.DisplayGameInfosMenu();
                    break;
                case "Save Game":
                    if(SaveGameManager.SaveGameToFile(player))
                    {
                        DisplayManager.DisplaySaveSuccess();
                    }
                    else
                    {
                        DisplayManager.DisplaySaveFailure();
                    }
                    break;
            }
        }
    }

    // Method to run a dotnet command and create a new CMD instance
    static void RunDotNetCommand(string command)
    {
        // Initialize a new CMD instance
        ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
        cmdStartInfo.FileName = "cmd.exe";
        cmdStartInfo.Arguments = "/c dotnet " + command;
        cmdStartInfo.CreateNoWindow = true;
        cmdStartInfo.UseShellExecute = true;
        Process cmdProcess = new Process();
        cmdProcess.StartInfo = cmdStartInfo;
        cmdProcess.Start();
        cmdProcess.WaitForExit();
    }
}