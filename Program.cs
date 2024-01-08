using Console_Crawler.GameCharacters;
using Console_Crawler.GameUtilities;
using Console_Crawler.GameUtilities.DisplayManager;
using Console_Crawler.GameVariables;
using System;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        RunDotNetCommand("run");

        // Initialize the game
        Player player = DisplayManager.InitializePlayerFromPreGameMenu();
        GameBools.IsGameRunning = true;
        GameBools.IsInMenu = true;

        while (GameBools.IsInMenu)
        {
            string menuChoice = DisplayManager.DisplayMainMenu(player);

            switch (menuChoice)
            {
                case "Enter Dungeon":
                    GameBools.IsInMenu = false;
                    GameBools.IsInBattle = true;
                    DisplayManager.StartDungeon(player);
                    break;
                case "Shop":
                    GameBools.IsInMenu = false;
                    GameBools.IsInShop = true;
                    DisplayManager.DisplayShopMenu(player);
                    break;
                case "Inventory":
                    GameBools.IsInMenu = false;
                    GameBools.IsInInventory = true;
                    DisplayManager.DisplayInventoryMenu(player);
                    break;
                case "Stats":
                    Console.WriteLine("Entering Stats ...");
                    break;
                case "Game Infos":
                    Console.WriteLine("Entering Game Infos ...");
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