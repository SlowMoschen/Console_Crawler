using Console_Crawler.GameCharacters;
using Console_Crawler.GameVariables;
using Console_Crawler.DungeonBuilder;
using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.GameCharacters.HostileMobs;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics;
using Console_Crawler.GameCharacters.HostileMobs.MiniBosses;

namespace Console_Crawler.GameUtilities.DisplayManager
{
    internal partial class DisplayManager
    {
        public static void StartDungeon(Player player)
        {
            DisplayHeader("Dungeon Selection");
            string dungeonChoice = GetDungenonChoice();

            while (dungeonChoice == "Boss" && !GameBools.IsBossDungeonUnlocked)
            {
                Console.WriteLine(" You have not unlocked the Boss Dungeon yet!");
                WaitForInput();
                dungeonChoice = GetDungenonChoice();
            }

            Dungeon dungeon = new Dungeon(dungeonChoice);

            DisplayEnteredDungeon(dungeonChoice, dungeon.TotalEnemies);

            foreach(Room room in dungeon.Rooms)
            {
                // Check if player is dead and quit if true break out of loop
                if(GameBools.IsInMenu)
                {
                    break;
                }

                if(GameBools.IsInBattle)
                {
                    DiplayEnteredRoom(room.RoomNumber, dungeon.TotalRooms, room.Enemies.Length);
                    EnterRoom(player, room);
                }

                if(AllEnemiesDeafeated(room))
                {
                    DisplayRoomVictory();
                    GameStatistics.AddSurviedRoom();
                }
            }
            
            if(AllRoomsDeafeated(dungeon))
            {
                GameBools.IsDungeonCleared = true;
            }

            if(GameBools.IsDungeonCleared)
            {
                DisplayDungeonVictory(dungeon, player);

                if(dungeon.IsBossDungeon)
                {
                    DisplayGameVictory();
                }
            }

        }
        
        public static void EnterRoom(Player player, Room room)
        {
            foreach(Enemy enemy in room.Enemies)
            {
                DisplayNewEncounter(enemy);
                while(player.Health > 0 && enemy.Health > 0 && GameBools.IsInBattle)
                {
                    EnemyBattle(player, enemy);
                }
            }
        }

        private static void EnemyBattle(Player player, Enemy enemy)
        {
            Console.WriteLine();
            DisplayBattleStats(player, enemy);
            Console.WriteLine();

            string battleChoice;

            // Check if player is stunned and skip turn if true
            if(!player.Effects.IsStunned)
            {
                battleChoice = GetPlayerBattleChoice();
                HandlePlayerBattleChoice(battleChoice, player, enemy);
            }
            else
            {
                Console.WriteLine(" You are stunned and can't move!");
                player.Effects.IsStunned = false;
            }

            // Quit if player is dead or has run away
            if(!GameBools.IsInBattle)
            {
                return;
            }

            player.DecrementBuffTurns();
            player.ApplyOverTimeEffects(enemy);
            enemy.DecrementBuffTurns();

            // Only execute enemy move if enemy is alive
            if (enemy.Health >= 0)
            {
                EnemyAction random = enemy.GetRandomAction();
                enemy.ExecuteAction(player, enemy.GetRandomAction());
            }
            else
            {
                HandleEnemyDeath(player, enemy);
            }

            if(player.Health > 0)
            {
                HandleBattleTurn(player, enemy);
            }
            else
            {
                HandlePlayerDeath();
            }

        }


        // Methods for getting player Choices
        private static string GetDungenonChoice()
        {
            return DisplayOptionsMenu(" Which dungeon would you like to enter?", MenuOptions.DifficultyOptions);
        }

        private static string GetPlayerBattleChoice()
        {
            return DisplayOptionsMenu(" What would you like to do?", MenuOptions.BattleOptions);
        }

        private static bool AllEnemiesDeafeated(Room room)
        {
            return room.Enemies.All(enemy => enemy.Health <= 0);
        }

        private static bool AllRoomsDeafeated(Dungeon dungeon)
        {
            return dungeon.Rooms.All(room => room.Enemies.All(enemy => enemy.Health <= 0));
        }

        private static void HandlePlayerBattleChoice(string choice, Player player, Enemy enemy)
        {
            switch (choice)
            {
                case "Attack":
                    player.ChooseAttack(enemy);
                    break;
                case "Rest":
                    player.Rest();
                    break;
                case "Use Item":
                    if(player.Inventory.Items.Count == 0)
                    {
                        Console.WriteLine(" You don't have any potions!");
                        WaitForInput();
                        Console.Clear();
                        EnemyBattle(player, enemy);
                        break;
                    }
                    string potionChoice = player.ChoosePotion();

                    if(potionChoice == "Go Back")
                    {
                        EnemyBattle(player, enemy);
                        break;
                    }

                    player.UsePotion(potionChoice);
                    break;
                case "Defend":
                    player.Defend();
                    break;
                case "Run Away":
                    player.RunFromBattle();
                    break;
            }
        }

        private static void HandleEnemyDeath(Player player, Enemy enemy)
        {
            GameStatistics.AddKilledEnemy();
            player.AddEXP(enemy.EXP);

            // check if enemy is Goblin or GoblinKing and get random number between Goblin Base Gold and the gold that the goblin has stolen - or just get the gold if not a goblin
            int goldAmount = enemy is Goblin
                ? Randomizer.GetRandomNumber(enemy.Gold, AllEnemyStatistics.Goblin.Gold) 
                :enemy is GoblinKing
                    ? Randomizer.GetRandomNumber(enemy.Gold, AllEnemyStatistics.GoblinKing.Gold)
                    : enemy.Gold;
            
            player.Inventory.AddGold(goldAmount);

            DisplayEnemyDeath(enemy, goldAmount);
        }

        private static void HandlePlayerDeath()
        {
            GameBools.IsInBattle = false;
            GameBools.IsInMenu = true;
            GameBools.IsDead = true;
            GameStatistics.AddTotalDeath();
            DisplayPlayerDeath();
            WaitForInput();
        }

        private static void HandleBattleTurn(Player player, Enemy enemy)
        {
            player.RegenEndurance();
            player.ClearDealtDamage();
            enemy.ClearDealtDamage();
            WaitForInput();
            Console.Clear();
        }

    }
}
