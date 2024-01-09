using Console_Crawler.GameCharacters;
using Console_Crawler.GameUtilities.Generators;
using Console_Crawler.GameVariables;
using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.GameVariables.Statistics.PlayerStatistics;

namespace Console_Crawler.GameUtilities.DisplayManager
{
    internal partial class DisplayManager
    {

        public static Player InitializePlayerFromPreGameMenu()
        {
            DisplayGreetings();
            AskForTutorial();
            GetPlayerName();
            Player player = new Player(
                name: PlayerStats.Name,
                attack: PlayerStats.InitialAttack,
                armor: PlayerStats.InitialArmor,
                strength: PlayerStats.InitialStrength,
                health: PlayerStats.InitialHealth
            );
            GetPlayerStartingWeapon(player);
            return player;
        }
        public static void DiplayGameLogo()
        {
            Console.Clear();
            DisplayHeader("Console_Crawler", "A simple console Dungeon Crawler");
            Console.WriteLine(" Version: " + GameStatistics.Version);
            Console.WriteLine();
        }

        public static void DisplayGreetings()
        {
            Console.Clear();
            DiplayGameLogo();
            Console.WriteLine(" Welcome to Console_Crawler!");
            Console.WriteLine(" The goal of this game is to get through the Boss Dungeon.");
            WaitForInput();
        }

        public static void AskForTutorial()
        {
            Console.Clear();
            DiplayGameLogo();
            string input = InputHandler.GetChoice("Do you want to read the Tutorial?", new string[] { "Yes", "No" });
            if (input == "Yes")
            {
                DisplayAllGameInfos();   
            }
        }

        public static void GetPlayerName()
        {
            Console.Clear();
            DiplayGameLogo();
            Console.WriteLine(" What is the name of your Hero?");
            PlayerStats.Name = Console.ReadLine();

            if (PlayerStats.Name == "")
            {
                PlayerStats.Name = "Player";
            }

            Console.WriteLine($" Your Hero will be called {PlayerStats.Name}!");
            WaitForInput();
        }

        public static void GetPlayerStartingWeapon( Player player )
        {
            Console.Clear();
            DiplayGameLogo();
            string input = DisplayOptionsMenu("Choose your starting weapon!", MenuOptions.StarterWeapons);
            player.EquipWeapon(WeaponGenerator.GenerateWeaponByChoice(input));
            Console.WriteLine($" Your Hero will use a {player.CurrentWeapon.WeaponName}!");
            WaitForInput();
        }
    }
}
