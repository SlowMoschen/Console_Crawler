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
            string optionChoice = "";
            string enemyMove = "";

            // Check if player is stunned and skip turn if true
            if(!player.Effects.IsStunned)
            {
                battleChoice = GetPlayerBattleChoice();
                optionChoice = HandlePlayerBattleChoice(battleChoice, player, enemy);
            }
            else
            {
                battleChoice = "Stunned";
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
                enemyMove = enemy.ExecuteAction(player, enemy.GetRandomAction());
            }

            if(player.Health <= 0)
            {
                HandlePlayerDeath();
                return;
            }

            // Check if enemy is dead and handle death or continue battle
            if(enemy.Health <= 0)
            {
                HandleEnemyDeath(player, enemy);           
            }
            else
            {
                HandleBattleTurn(player, enemy, battleChoice, optionChoice, enemyMove);
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

        private static string HandlePlayerBattleChoice(string choice, Player player, Enemy enemy)
        {
            switch (choice)
            {
                case "Attack":
                    return player.ChooseAttack(enemy);
                case "Rest":
                    player.Rest();
                    break;
                case "Use Item":
                    if(player.Inventory.Items.Count == 0)
                    {
                        Console.WriteLine(" You don't have any potions!");
                        WaitForInput();
                        break;
                    }
                    string potionChoice = player.ChoosePotion();

                    if(potionChoice == "Go Back")
                    {
                        EnemyBattle(player, enemy);
                        break;
                    }

                    player.UsePotion(potionChoice);
                    return potionChoice;
                case "Defend":
                    player.Defend();
                    break;
                case "Run Away":
                    player.RunFromBattle();
                    break;
            }

            return "";
        }

        private static void HandleEnemyDeath(Player player, Enemy enemy)
        {
            GameStatistics.AddKilledEnemy();
            player.AddEXP(enemy.EXP);

            // check if enemy is Goblin or GoblinKing and get random number between Goblin Base Gold and the gold that the goblin has stolen - or just get the gold if not a goblin
            int goldAmount = enemy is Goblin
                ? Randomizer.GetRandomNumber(AllEnemyStatistics.Goblin.Gold, enemy.Gold) 
                :enemy is GoblinKing
                    ? Randomizer.GetRandomNumber(AllEnemyStatistics.Goblin.Gold, enemy.Gold)
                    : enemy.Gold;

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

        private static void HandleBattleTurn(Player player, Enemy enemy, string battleChoice, string optionChoice, string enemyMove)
        {
            DisplayRoundResults(player, enemy, battleChoice, optionChoice, enemyMove);
            player.RegenEndurance();
            player.ClearDealtDamage();
            enemy.ClearDealtDamage();
            WaitForInput();
            Console.Clear();
        }

    }
}
