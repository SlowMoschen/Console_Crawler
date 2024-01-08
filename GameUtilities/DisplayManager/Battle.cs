using Console_Crawler.GameCharacters;
using Console_Crawler.GameVariables;
using Console_Crawler.DungeonBuilder;
using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.GameCharacters.HostileMobs;
using Console_Crawler.GameCharacters.HostileMobs.MiniBosses;
using Console_Crawler.GameCharacters.HostileMobs.Bosses;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics;

namespace Console_Crawler.GameUtilities.DisplayManager
{
    internal partial class DisplayManager
    {
        public static void StartDungeon(Player player)
        {
            DisplayHeader("Dungeon Selection");
            string dungeonChoice = DisplayOptionsMenu(" Which dungeon would you like to enter?", MenuOptions.DifficultyOptions);

            while (dungeonChoice == "Boss" && !GameBools.IsBossDungeonUnlocked)
            {
                Console.WriteLine(" You have not unlocked the Boss Dungeon yet!");
                WaitForInput();
                dungeonChoice = DisplayOptionsMenu(" Which dungeon would you like to enter?", MenuOptions.DifficultyOptions);
            }

            Dungeon dungeon = new Dungeon(dungeonChoice);

            DisplayEnteredDungeon(dungeonChoice, dungeon.TotalEnemies);

            foreach(Room room in dungeon.Rooms)
            {
                bool allEnemiesDefeated = room.Enemies.All(enemy => enemy.Health <= 0);
                bool allRoomsDefeated = dungeon.Rooms.All(room => room.Enemies.All(enemy => enemy.Health <= 0));
                
                if(GameBools.IsInMenu)
                {
                    break;
                }

                if(allEnemiesDefeated)
                {
                    DisplayRoomVictory();
                    GameStatistics.SurviedRooms++;
                }

                if(allRoomsDefeated)
                {
                    GameBools.IsDungeonCleared = true;
                    break;
                }

                if(GameBools.IsInBattle)
                {
                    DiplayEnteredRoom(room.RoomNumber, dungeon.TotalRooms, room.Enemies.Length);
                    EnterRoom(player, room);
                }
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

            string battleChoice = DisplayOptionsMenu(" What would you like to do?", MenuOptions.BattleOptions);
            string attackChoice = "";

            if(!player.Effects.IsStunned)
            {
                switch(battleChoice)
                {
                    case "Attack":
                        attackChoice = player.ChooseAttack(enemy);
                        break;
                    case "Rest":
                        player.Rest();
                        break;
                    case "Use Potion":
                         
                        if(player.Inventory.Items.Count == 0)
                         {
                            Console.WriteLine(" You don't have any potions!");
                            WaitForInput();
                            break;
                         }

                        battleChoice = player.ChoosePotion();
                        player.UsePotion(battleChoice);
                        break;
                    case "Defend":
                        player.Defend();
                        break;
                    case "Run":
                        player.RunFromBattle();
                        break;
                }
            }
            else
            {
                Console.WriteLine(" You are stunned and can't do anything!");
                player.Effects.IsStunned = false;
                battleChoice = "Stunned";
            }

            if(!GameBools.IsInBattle)
            {
                return;
            }

            string enemyMove = enemy.ExecuteAction(player, enemy.GetRandomAction());
            player.DecrementBuffTurns();
            player.ApplyOverTimeEffects(enemy);

            if(enemy.Health <= 0)
            {
                GameStatistics.KilledEnemies++;
                player.AddEXP(enemy.EXP);
                
                // check if enemy is Goblin and get random number between Goblin Base Gold and the gold that the goblin has stolen
                if(enemy is Goblin goblin)
                {
                    player.Inventory.AddGold(Randomizer.GetRandomNumber(AllEnemyStatistics.Goblin.Gold, goblin.Gold));
                }
                else
                {
                    player.Inventory.AddGold(enemy.Gold);
                }

                DisplayEnemyDeath(enemy);
                return;
            }
            else
            {
                DisplayRoundResults(player, enemy, battleChoice, attackChoice, enemyMove);
                WaitForInput();
                Console.Clear();
            }
        }

        private static void DisplayRoundResults(Player player, Enemy enemy, string playerMove, string playerAttackChoice, string enemyMove)
        {
            DisplayPlayerMove(player, enemy, playerMove, playerAttackChoice, enemyMove);
            DisplayEnemyMove(player, enemy, enemyMove);
        }

        private static void DisplayPlayerMove(Player player, Enemy enemy, string playerMove, string playerAttackChoice, string enemyMove)
        {
            switch (playerMove)
            {
                case "Attack":
                    if (enemyMove == "Defend")
                    {
                        Console.WriteLine($" You tried to attack the {enemy.Name} but it defended!");
                    }
                    else
                    {
                        if (playerAttackChoice == "Normal Attack")
                        {
                            Console.WriteLine($" You attacked the enemy for {player.DealtDamage}");
                        }
                        if (playerAttackChoice == "Kick Attack")
                        {
                            Console.WriteLine($" You kicked the enemy for {player.DealtDamage}");
                        }
                        if (playerAttackChoice == player.CurrentWeapon.WeaponStats.SpecialAttackName)
                        {
                            Console.WriteLine($" You used {player.CurrentWeapon.WeaponStats.SpecialAttackName} and dealt {player.DealtDamage} damage!");
                        }
                    }
                    break;
                case "Rest":
                    Console.WriteLine($" You rested and gained {GameSettings.General.RestHealthRegen} health and {GameSettings.General.RestEnduranceRegen + GameSettings.General.RoundEnduranceRegen} endurance!");
                    break;
                case "Use Potion":
                    Console.WriteLine($" You used a {playerMove}!");
                    if (playerMove == "Health Potion")
                    {
                        Console.WriteLine($" You gained {ItemSettings.ItemEffect.HealPotion} health!");
                    }
                    if (playerMove == "Strength Potion")
                    {
                        Console.WriteLine(" Your next attacks will deal double the damage!");
                    }
                    if (playerMove == "Endurance Potion")
                    {
                        Console.WriteLine($" You gained {ItemSettings.ItemEffect.EndurancePotion} endurance!");
                    }
                    break;
                case "Defend":
                    if (player.Effects.IsDefending)
                    {
                        Console.WriteLine(" You are Defending the next attack!");
                    }
                    else
                    {
                        Console.WriteLine(" You succsessfully defended the attack!");
                    }
                    break;
                case "Run":
                    Console.WriteLine(" You ran away from the battle!");
                    break;
                case "Stunned":
                    Console.WriteLine(" You are stunned and can't do anything!");
                    break;
            }
        }

        private static void DisplayEnemyMove( Player player, Enemy enemy, string enemyMove )
        {
            switch (enemyMove)
            {
                case "Normal Attack":
                    Console.WriteLine($" The {enemy.Name} attacked you for {enemy.DealtDamage} damage!");
                    break;
                case "Defend":
                    Console.WriteLine($" The {enemy.Name} is defending the next attack!");
                    break;
                case "Bite":
                    Console.WriteLine($" The {enemy.Name} bit you for {enemy.DealtDamage} damage and healed itself for {enemy.DealtDamage / 2} health!");
                    break;
                case "Thrash":
                    Console.WriteLine($" The {enemy.Name} thrashed you for {enemy.DealtDamage} damage and took {enemy.DealtDamage / 4} damage itself!");
                    break;
                case "Slam":
                    Console.WriteLine($" The {enemy.Name} slammed you for {enemy.DealtDamage} damage!");
                    if (player.Effects.IsStunned)
                    {
                        Console.WriteLine(" The enmey stunned you!");
                    }
                    break;
                case "Spit":
                    if(enemy is Spider spider)
                    {
                        if(player.Effects.IsPoisoned)
                        {
                            Console.WriteLine($" The {spider.Name} spit at you for {spider.DealtDamage} damage and poisoned you!");
                            Console.WriteLine($" You took {spider.PoisonDamage} damage from the poison!");
                            Console.WriteLine($" You are poisoned for the next {player.EffectTurns.PoisonTurns} turns!");
                        }
                        else
                        { 
                            Console.WriteLine($" The {spider.Name} spit at you for {spider.DealtDamage} damage!");
                        }
                    }
                    break;
                case "Steal":
                    if(enemy is Goblin goblin)
                    {
                        if(player.Inventory.Gold > 0)
                        {
                            Console.WriteLine($" The {goblin.Name} stole {goblin.StealAmount} gold from you!");
                        }
                    }
                    break;
                case "Backstab":
                    if(enemy is Assassin assassin)
                    {
                        Console.WriteLine($" The {assassin.Name} backstabbed you for {assassin.DealtDamage} damage!");
                    }
                    break;
                case "Poison Bite":
                    if(enemy is GiantSpider giantSpider)
                    {
                        if(player.Effects.IsPoisoned)
                        {
                            Console.WriteLine($" The {giantSpider.Name} bit you for {giantSpider.DealtDamage} damage and poisoned you!");
                            Console.WriteLine($" You took {giantSpider.PoisonDamage} damage from the poison!");
                            Console.WriteLine($" You are poisoned for the next {player.EffectTurns.PoisonTurns} turns!");
                        }
                        else
                        {
                            Console.WriteLine($" The {giantSpider.Name} bit you for {giantSpider.DealtDamage} damage!");
                        }
                    }
                    break;
                case "Webshot":
                    if(enemy is GiantSpider giantSpider2)
                    {
                        Console.WriteLine($" The {giantSpider2.Name} webshot you for {giantSpider2.DealtDamage} damage!");
                        if(player.Effects.IsStunned)
                        {
                            Console.WriteLine(" The enmey stunned you!");
                        }
                    }
                    break;
                case "Hellfire Blast":
                    if(enemy is DemonicSorcerer sorcerer)
                    {
                        Console.WriteLine($" The {sorcerer.Name} used Hellfire Blast and dealt {sorcerer.DealtDamage} damage!");
                        if(player.Effects.IsBurning)
                        {
                            Console.WriteLine($" You took {sorcerer.BurnDamage} damage from the burn!");
                            Console.WriteLine($" You are burning for the next {player.EffectTurns.BurnTurns} turns!");
                        }
                    }
                    break;
                case "Soulsteal":
                    if(enemy is DemonicSorcerer sorcerer2)
                    {
                        Console.WriteLine($" The {sorcerer2.Name} used Soulsteal and dealt {sorcerer2.DealtDamage} damage and healed itself for {sorcerer2.DealtDamage / 2} health!");
                    }
                    break;
                case "Dark Pact":
                    if(enemy is DemonicSorcerer sorcerer3)
                    {
                        Console.WriteLine($" The {sorcerer3.Name} used Dark Pact and increased his attack damage by 20% for 10% of its health.");
                    }
                    break;
                case "Fire Breath":
                    if(enemy is Dragon dragon)
                    {
                        Console.WriteLine($" The {dragon.Name} used Fire Breath and dealt {dragon.DealtDamage} damage!");
                        if(player.Effects.IsBurning)
                        {
                            Console.WriteLine($" You took {dragon.BurnDamage} damage from the burn!");
                            Console.WriteLine($" You are burning for the next {player.EffectTurns.BurnTurns} turns!");
                        }
                    }
                    break;
                case "Rock Throw":
                    if(enemy is Dragon dragon2)
                    {
                        Console.WriteLine($" The {dragon2.Name} used Rock Throw and dealt {dragon2.DealtDamage} damage!");
                        if(player.Effects.IsStunned)
                        {
                            Console.WriteLine(" The enmey stunned you!");
                        }
                    }
                    break;
                case "Tailstrike":
                    if(enemy is Dragon dragon3)
                    {
                        Console.WriteLine($" The {dragon3.Name} used Tailstrike and dealt {dragon3.DealtDamage} damage!");
                    }
                    break;
            }
        }

        private static void DisplayEnemyDeath(Enemy enemy)
        { 
            Console.WriteLine($" You have defeated the {enemy.Name}!");
            Console.WriteLine($" You gained {enemy.EXP} experience.");
            Console.WriteLine($" The enemy dropped {enemy.Gold} gold.");
            WaitForInput();
        }

        private static void DisplayNewEncounter(Enemy enemy)
        {
            Console.Clear();
            DisplayHeader("New Encounter");
            Console.WriteLine($" You have encountered a {enemy.Name}!");
        }

        private static void DisplayBattleStats(Player player, Enemy enemy)
        {
            Console.WriteLine();
            player.PrintBattleStats();
            DisplayHeader("VS");
            enemy.PrintBattleStats();
        }

        private static void DisplayEnteredDungeon(string difficulty, int totalEnemis)
        {
           string pluralOrSingular = totalEnemis > 1 ? "Enemies" : "Enemy";
           
           Console.Clear();
           DisplayHeader($"New Dungeon");
           Console.WriteLine($" You have entered the {difficulty} Dungeon!");
           Console.WriteLine($" You have to defeat in total {totalEnemis} {pluralOrSingular} to get through this Dungeon.");
           WaitForInput();
        }

        private static void DiplayEnteredRoom(int roomNumber, int totalRooms, int enemiesCount)
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

        private static void DisplayDungeonVictory(Dungeon dungeon, Player player)
        {
            GameBools.IsInMenu = true;
            GameBools.IsInBattle = false;
            GameBools.IsDungeonCleared = false;
            GameStatistics.SurviedDungeons++;
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
