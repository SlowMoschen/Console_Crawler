﻿using Console_Crawler.DungeonBuilder;
using Console_Crawler.GameCharacters;
using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.GameVariables;

namespace Console_Crawler.GameUtilities.DisplayManager
{
    internal partial class DisplayManager
    {
        private static void DisplayEnemyDeath( Enemy enemy, int goldAmount )
        {
            Console.WriteLine($" You have defeated the {enemy.Name}!");
            Console.WriteLine($" You gained {enemy.EXP} experience.");
            Console.WriteLine($" The enemy dropped {goldAmount} gold.");
        }

        private static void DisplayPlayerDeath()
        {
            Console.Clear();
            DisplayHeader("R.I.P");
            Console.WriteLine(" You have died!");
        }

        private static void DisplayNewEncounter( Enemy enemy )
        {
            Console.Clear();
            DisplayHeader("New Encounter");
            Console.WriteLine($" You have encountered a {enemy.Name}!");
        }

        private static void DisplayBattleStats( Player player, Enemy enemy )
        {
            Console.WriteLine();
            player.PrintBattleStats();
            DisplaySubHeader("VS");
            enemy.PrintBattleStats();
        }

        private static void DisplayEnteredDungeon( string difficulty, int totalEnemis )
        {
            string pluralOrSingular = totalEnemis > 1 ? "Enemies" : "Enemy";

            Console.Clear();
            DisplayHeader("New Dungeon");
            Console.WriteLine($" You have entered the {difficulty} Dungeon!");
            Console.WriteLine($" You have to defeat in total {totalEnemis} {pluralOrSingular} to get through this Dungeon.");
            WaitForInput();
        }

        private static void DiplayEnteredRoom( int roomNumber, int totalRooms, int enemiesCount )
        {
            bool isPlural = enemiesCount > 1;

            Console.Clear();
            DisplayHeader("New Room");
            Console.WriteLine($" You have entered Room {roomNumber} of {totalRooms}.");
            Console.WriteLine($" There {(isPlural ? "are" : "is")} {enemiesCount} {(isPlural ? "Enemies" : "Enmey")} in this room.");
            WaitForInput();
        }

        private static void DisplayRoomVictory()
        {
            Console.Clear();
            DisplayHeader("Room Victory");
            Console.WriteLine(" You have defeated all enemies in this room!");
            WaitForInput();
        }

        private static void DisplayDungeonVictory( Dungeon dungeon, Player player )
        {
            GameBools.IsInMenu = true;
            GameBools.IsInBattle = false;
            GameBools.IsDungeonCleared = false;
            GameStatistics.AddSurviedDungeon();
            Console.Clear();
            DisplayHeader("Dungeon Victory");
            Console.WriteLine(" You have defeated all enemies in this dungeon!");
            Console.WriteLine();
            DisplayHeader("Rewards");
            dungeon.Chest.OpenChest(player);
            WaitForInput();
        }

        private static void DisplayGameVictory()
        {
            GameBools.IsInMenu = true;
            GameBools.IsInBattle = false;
            GameBools.IsDungeonCleared = false;
            Console.Clear();
            DisplayHeader("Game Victory");
            Console.WriteLine(" You have defeated the Boss and won the game!");
            WaitForInput();
        }
    }
}
