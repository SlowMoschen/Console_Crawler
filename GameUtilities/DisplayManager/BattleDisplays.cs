using Console_Crawler.DungeonBuilder;
using Console_Crawler.GameCharacters;
using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.GameVariables;
using Console_Crawler.GameCharacters.HostileMobs.Bosses;
using Console_Crawler.GameCharacters.HostileMobs.MiniBosses;
using Console_Crawler.GameCharacters.HostileMobs;

namespace Console_Crawler.GameUtilities.DisplayManager
{
    internal partial class DisplayManager
    {

        private static void DisplayRoundResults( Player player, Enemy enemy, string playerMove, string optionChoice, string enemyMove )
        {
            DisplayPlayerMove(player, enemy, playerMove, optionChoice, enemyMove);
            DisplayEnemyMove(player, enemy, enemyMove);
        }

        private static void DisplayPlayerMove( Player player, Enemy enemy, string playerMove, string optionChoice, string enemyMove )
        {
            switch (playerMove)
            {
                case "Attack":
                    if (enemyMove == "Defend")
                    {
                        Console.WriteLine($" You tried to attack the {enemy.Name} but it defended!");
                    }
                    break;
                case "Rest":
                    Console.WriteLine($" You rested and gained {GameSettings.General.RestHealthRegen} health and {GameSettings.General.RestEnduranceRegen + GameSettings.General.RoundEnduranceRegen} endurance!");
                    break;
                case "Use Potion":
                    Console.WriteLine($" You used a {optionChoice}!");
                    if (optionChoice == "Health Potion")
                    {
                        Console.WriteLine($" You gained {ItemSettings.ItemEffect.HealPotion} health!");
                    }
                    if (optionChoice == "Strength Potion")
                    {
                        Console.WriteLine(" Your next attacks will deal double the damage!");
                    }
                    if (optionChoice == "Endurance Potion")
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
                        // Those Attacks can't be defended
                        if(enemy is Assassin && enemyMove == "Backstab" || enemy is Dragon && enemyMove == "Tailstrike")
                        {
                            Console.WriteLine(" You tried to defend the next attack but the enemy is too fast!");
                        }
                        else
                        { 
                            Console.WriteLine(" You succsessfully defended the attack!");
                        }

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
                    if (enemy is Spider spider)
                    {
                        if (player.Effects.IsPoisoned)
                        {
                            Console.WriteLine($" The {spider.Name} spit at you for {spider.DealtDamage} damage and poisoned you!");
                            Console.WriteLine($" You are poisoned for the next {player.EffectTurns.PoisonTurns} turns!");
                        }
                        else
                        {
                            Console.WriteLine($" The {spider.Name} spit at you for {spider.DealtDamage} damage!");
                        }
                    }
                    break;
                case "Steal":
                    if (enemy is Goblin goblin)
                    {
                        Console.WriteLine($" The {goblin.Name} dealt {goblin.DealtDamage} damage!");
                        if (player.Inventory.Gold > 0)
                        {
                            Console.WriteLine($" The {goblin.Name} stole {goblin.StealAmount} gold from you!");
                        }
                    }
                    break;
                case "Backstab":
                    if (enemy is Assassin assassin)
                    {
                        Console.WriteLine($" The {assassin.Name} backstabbed you for {assassin.DealtDamage} damage!");
                    }
                    break;
                case "Poison Bite":
                    if (enemy is GiantSpider giantSpider)
                    {
                        if (player.Effects.IsPoisoned)
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
                    if (enemy is GiantSpider giantSpider2)
                    {
                        Console.WriteLine($" The {giantSpider2.Name} webshot you for {giantSpider2.DealtDamage} damage!");
                        if (player.Effects.IsStunned)
                        {
                            Console.WriteLine(" The enmey stunned you!");
                        }
                    }
                    break;
                case "Hellfire Blast":
                    if (enemy is DemonicSorcerer sorcerer)
                    {
                        Console.WriteLine($" The {sorcerer.Name} used Hellfire Blast and dealt {sorcerer.DealtDamage} damage!");
                        if (player.Effects.IsBurning)
                        {
                            Console.WriteLine($" You took {sorcerer.BurnDamage} damage from the burn!");
                            Console.WriteLine($" You are burning for the next {player.EffectTurns.BurnTurns} turns!");
                        }
                    }
                    break;
                case "Soulsteal":
                    if (enemy is DemonicSorcerer sorcerer2)
                    {
                        Console.WriteLine($" The {sorcerer2.Name} used Soulsteal and dealt {sorcerer2.DealtDamage} damage and healed itself for {sorcerer2.DealtDamage / 2} health!");
                    }
                    break;
                case "Dark Pact":
                    if (enemy is DemonicSorcerer sorcerer3)
                    {
                        Console.WriteLine($" The {sorcerer3.Name} used Dark Pact and increased his attack damage by 20% for 10% of its health.");
                    }
                    break;
                case "Fire Breath":
                    if (enemy is Dragon dragon)
                    {
                        Console.WriteLine($" The {dragon.Name} used Fire Breath and dealt {dragon.DealtDamage} damage!");
                        if (player.Effects.IsBurning)
                        {
                            Console.WriteLine($" You took {dragon.BurnDamage} damage from the burn!");
                            Console.WriteLine($" You are burning for the next {player.EffectTurns.BurnTurns} turns!");
                        }
                    }
                    break;
                case "Rock Throw":
                    if (enemy is Dragon dragon2)
                    {
                        Console.WriteLine($" The {dragon2.Name} used Rock Throw and dealt {dragon2.DealtDamage} damage!");
                        if (player.Effects.IsStunned)
                        {
                            Console.WriteLine(" The enmey stunned you!");
                        }
                    }
                    break;
                case "Tailstrike":
                    if (enemy is Dragon dragon3)
                    {
                        Console.WriteLine($" The {dragon3.Name} used Tailstrike and dealt {dragon3.DealtDamage} damage!");
                    }
                    break;
            }
        }

        private static void DisplayEnemyDeath( Enemy enemy, int goldAmount )
        {
            Console.WriteLine($" You have defeated the {enemy.Name}!");
            Console.WriteLine($" You gained {enemy.EXP} experience.");
            Console.WriteLine($" The enemy dropped {goldAmount} gold.");
            WaitForInput();
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
