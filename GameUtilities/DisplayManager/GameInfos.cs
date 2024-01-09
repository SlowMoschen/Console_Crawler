using Console_Crawler.GameVariables;
using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics;
using Console_Crawler.GameVariables.Statistics.WeaponStatistics;

namespace Console_Crawler.GameUtilities.DisplayManager
{
    internal partial class DisplayManager
    {

        private static void DisplayAllGameInfos()
        {
            Console.Clear();
            DisplayGameplayInfos();
            Console.Clear();
            DisplayBattleInfos();
            Console.Clear();
            DisplayItemInfos();
            Console.Clear();
            DisplayWeaponInfos();
            Console.Clear();
            DisplayEnemyInfos();
            Console.Clear();
            DisplayCredits();
        }
        private static void DisplayCredits()
        {
            DisplayHeader("Credits");
            Console.WriteLine();
            Console.WriteLine(" Gameversion:");
            Console.WriteLine($"    {GameStatistics.Version}");
            Console.WriteLine();
            Console.WriteLine(" Game written in:");
            Console.WriteLine("     C# .NET core 8.0");
            Console.WriteLine();
            Console.WriteLine(" This game was created by:");
            Console.WriteLine();
            Console.WriteLine("     Game Design and Programming:");
            Console.WriteLine("         by Philipp Millner");
            Console.WriteLine();
            Console.WriteLine("     Testing:");
            Console.WriteLine("         by Philipp Millner");
            Console.WriteLine();
            Console.WriteLine("     Special Thanks:");
            Console.WriteLine("         to the people who helped me with the game testing and gave me feedback.");
            Console.WriteLine();
            Console.WriteLine("     Github:");
            Console.WriteLine("         https://github.com/SlowMoschen");
            Console.WriteLine();
            Console.WriteLine("     Github Project Repository:");
            Console.WriteLine("         https://github.com/SlowMoschen/Console_Crawler");
            Console.WriteLine();
            Console.WriteLine(" This game is licensed under MIT License.");
            Console.WriteLine(" For more information see the LICENSE file in the project repository.");
            Console.WriteLine();
            Console.WriteLine(" Thank you for playing.");
            WaitForInput();
        }
        
        private static void DisplayGameplayInfos()
        {
            DisplayHeader("Gameplay Infos");
            Console.WriteLine();
            Console.WriteLine(" Gameplay:");
            Console.WriteLine();
            Console.WriteLine("     The Game is turn based");
            Console.WriteLine("     The Dungeon is split into different rooms. Each room has a set amount of different enemies");
            Console.WriteLine("     Every enemy in each Room will be fought in a 1 vs 1 battle");
            Console.WriteLine("     Enemies award experience and gold on defeat");
            Console.WriteLine("     The highest achivable level is 30");
            Console.WriteLine("     After defeating all enemies in a room, you can enter the next room");
            Console.WriteLine("     After defeating all enemies in the Dungeon, you will get a reward");
            Console.WriteLine("     You can choose between different options in the Main Menu");
            Console.WriteLine("     You can enter the Dungeon, view your stats, view your inventory or go to the Shop");
            Console.WriteLine("     You can buy potions in the Shop to heal, increase your strength or increase your endurance");
            WaitForInput();
        }

        private static void DisplayBattleInfos()
        {
            DisplayHeader("Battle Infos");
            Console.WriteLine();
            Console.WriteLine(" Battle:");
            Console.WriteLine();
            Console.WriteLine("     You can choose between different options to attack, defend, rest or run away");
            Console.WriteLine("     You can attack with your weapons normal attack,");
            Console.WriteLine("     or use a special attack wich costs more endurance but deals more damage");
            Console.WriteLine("     You can only attack if you have enough endurance so keep an eye on your endurance");
            Console.WriteLine("     You will get some endurance back after each turn");
            Console.WriteLine("     You can defend to take less damage from the enemy's attack");
            Console.WriteLine("     The damage calculation is as follows: (Attack Damage * Strength) * Damage Reduction");
            Console.WriteLine("     The damage reduction is calculated by the armor in percent");
            Console.WriteLine("     You can defend to take no damage from the enemy's attack");
            Console.WriteLine("     You can rest to heal and regenerate endurance");
            Console.WriteLine("     You can use potions to heal, increase your strength or increase your endurance");
            Console.WriteLine("     You can only use one potion per turn");
            Console.WriteLine("     You can run away to end the fight, but you get no reward and you lose half of your Gold");
            WaitForInput();
        }

        private static void DisplayItemInfos()
        {
            DisplayHeader("Items Infos");
            Console.WriteLine();
            Console.WriteLine(" Items:");
            Console.WriteLine();
            Console.WriteLine("     Health Potion:");
            Console.WriteLine();
            Console.WriteLine($"        The healing is scaling with the Playerlevel.");
            Console.WriteLine();
            Console.WriteLine($"        Heals you for {ItemSettings.ItemEffect.HealPotion} health.");
            Console.WriteLine($"        Costs {ItemSettings.ItemPrice.HealPotion} gold.");
            Console.WriteLine();
            Console.WriteLine("     Strength Potion:");
            Console.WriteLine();
            Console.WriteLine($"        Increases your strength for {GameSettings.EffectDurations.StrengthPotion} turns.");
            Console.WriteLine($"        Costs {ItemSettings.ItemPrice.StrengthPotion} gold.");
            Console.WriteLine();
            Console.WriteLine("     Endurance Potion:");
            Console.WriteLine();
            Console.WriteLine($"        Regenerates {ItemSettings.ItemEffect.StrengthPotion} endurance.");
            Console.WriteLine($"        Costs {ItemSettings.ItemPrice.EndurancePotion} gold.");
            WaitForInput();
        }

        private static void DisplayWeaponInfos()
        {
            DisplayHeader("Weapons Infos");
            Console.WriteLine();
            Console.WriteLine(" You got 3 different weapons to choose at the start of the game");
            Console.WriteLine(" Each weapon has a normal attack and a different special attack");
            Console.WriteLine(" The special attack costs more endurance but deals segniificantly more damage");
            Console.WriteLine(" The special attack damage is calculated by the attack damage + the special attack strength");
            Console.WriteLine();
            Console.WriteLine($" Weapons are getting stronger after {GameSettings.General.WeaponUpgradeInterval} levels");
            Console.WriteLine(" New Weapons can be found in chests after defeating all enemies in a Dungeon");
            Console.WriteLine();
            Console.WriteLine(" Weapons:");
            Console.WriteLine();
            Console.WriteLine("     Sword:");
            Console.WriteLine();
            Console.WriteLine($"        Attack: The attack damage can vary between {WeaponStats.Sword.MinBaseDamage} and {WeaponStats.Sword.MaxBaseDamage}");
            Console.WriteLine($"        Endurance Consumption: {WeaponStats.Sword.EnduranceCost}");
            Console.WriteLine($"        Special Attack: The special attack damage can vary between {WeaponStats.Sword.MinSpecialDamage} and {WeaponStats.Sword.MaxSpecialDamage}");
            Console.WriteLine($"        Special Attack Endurance Consumption: {WeaponStats.Sword.SpecialEnduranceCost}");
            Console.WriteLine();
            Console.WriteLine("     Axe:");
            Console.WriteLine();
            Console.WriteLine($"        Attack: The attack damage can vary between {WeaponStats.Axe.MinBaseDamage} and {WeaponStats.Axe.MaxBaseDamage}");
            Console.WriteLine($"        Endurance Consumption: {WeaponStats.Axe.EnduranceCost}");
            Console.WriteLine($"        Special Attack: The special attack damage can vary between {WeaponStats.Axe.MinSpecialDamage} and {WeaponStats.Axe.MaxSpecialDamage}");
            Console.WriteLine($"        Special Attack Endurance Consumption: {WeaponStats.Axe.SpecialEnduranceCost}");
            Console.WriteLine();
            Console.WriteLine("     Mace:");
            Console.WriteLine();
            Console.WriteLine($"        Attack: The attack damage can vary between {WeaponStats.Mace.MinBaseDamage} and {WeaponStats.Mace.MaxBaseDamage}");
            Console.WriteLine($"        Endurance Consumption: {WeaponStats.Mace.EnduranceCost}");
            Console.WriteLine($"        Special Attack: The special attack damage can vary between {WeaponStats.Mace.MinSpecialDamage} and {WeaponStats.Mace.MaxSpecialDamage}");
            Console.WriteLine($"        Special Attack Endurance Consumption: {WeaponStats.Mace.SpecialEnduranceCost}");
            WaitForInput();
        }

        private static void DisplayEnemyInfos()
        {
            DisplayHeader("Enemies Infos");
            Console.WriteLine();
            Console.WriteLine(" Every enemy has different stats and attacks");
            Console.WriteLine(" Enemies can attack, defend or use a special attack");
            Console.WriteLine(" Enemies can also have special abilities like poisoning or stunning");
            Console.WriteLine();
            Console.WriteLine(" Some of the stats are scaling with the player's level");
            Console.WriteLine(" The scaling is as follows:");
            Console.WriteLine("     BaseStat + (PlayerLevel - 1 / scaleInterval) * ScaleRating");
            Console.WriteLine();
            Console.WriteLine(" The scale Intervals are all to 1 Level, so the stats scale every Playerlevel");
            Console.WriteLine(" The scaling Ratings are as follows:");
            Console.WriteLine($"     Attack: {GameSettings.EnemyScaling.AttackScaling}");
            Console.WriteLine($"     Armor: {GameSettings.EnemyScaling.ArmorScaling} - currently disabled");
            Console.WriteLine($"     Health: {GameSettings.EnemyScaling.HealthScaling}");
            Console.WriteLine($"     EXP: {GameSettings.EnemyScaling.EXPSScaling}");
            Console.WriteLine();
            Console.WriteLine(" Here are the different enemies you can encounter in the game listed:");
            Console.WriteLine();
            Console.WriteLine(" Enemies:");
            Console.WriteLine();
            Console.WriteLine("     Zombie:");
            Console.WriteLine();
            Console.WriteLine($"        Health: {AllEnemyStatistics.Zombie.BaseHealth}");
            Console.WriteLine($"        Attack: {AllEnemyStatistics.Zombie.BaseAttack}");
            Console.WriteLine($"        Armor: {AllEnemyStatistics.Zombie.BaseArmor}");
            Console.WriteLine($"        Strength: {AllEnemyStatistics.Zombie.Strength}");
            Console.WriteLine($"        EXP: {AllEnemyStatistics.Zombie.BaseEXP}");
            Console.WriteLine($"        Gold: {AllEnemyStatistics.Zombie.Gold}");
            Console.WriteLine($"        Special Attacks:");
            Console.WriteLine();
            Console.WriteLine("            Bite:");
            Console.WriteLine();
            Console.WriteLine($"                Heals the Zombie for half of the damage dealt.");
            Console.WriteLine();
            Console.WriteLine("            Thrash:");
            Console.WriteLine();
            Console.WriteLine($"                Deals Damage to itself and the player.");
            Console.WriteLine();
            Console.WriteLine("     Spider:");
            Console.WriteLine();
            Console.WriteLine($"        Health: {AllEnemyStatistics.Spider.BaseHealth}");
            Console.WriteLine($"        Attack: {AllEnemyStatistics.Spider.BaseAttack}");
            Console.WriteLine($"        Armor: {AllEnemyStatistics.Spider.BaseArmor}");
            Console.WriteLine($"        Strength: {AllEnemyStatistics.Spider.Strength}");
            Console.WriteLine($"        EXP: {AllEnemyStatistics.Spider.BaseEXP}");
            Console.WriteLine($"        Gold: {AllEnemyStatistics.Spider.Gold}");
            Console.WriteLine($"        Special Attacks:");
            Console.WriteLine();
            Console.WriteLine("            Spit:");
            Console.WriteLine();
            Console.WriteLine($"                Deals damage to the player and got a {AllEnemyStatistics.Spider.PoisonChance}% chance tp poison the player");
            Console.WriteLine($"                Poison deals {AllEnemyStatistics.Spider.BasePoisonDamage} base damage for {GameSettings.EffectDurations.Poison} turns.");
            Console.WriteLine();
            Console.WriteLine("     Goblin:");
            Console.WriteLine();
            Console.WriteLine($"        Health: {AllEnemyStatistics.Goblin.BaseHealth}");
            Console.WriteLine($"        Attack: {AllEnemyStatistics.Goblin.BaseAttack}");
            Console.WriteLine($"        Armor: {AllEnemyStatistics.Goblin.BaseArmor}");
            Console.WriteLine($"        Strength: {AllEnemyStatistics.Goblin.Strength}");
            Console.WriteLine($"        EXP: {AllEnemyStatistics.Goblin.BaseEXP}");
            Console.WriteLine($"        Gold: {AllEnemyStatistics.Goblin.Gold}");
            Console.WriteLine($"        Special Attacks:");
            Console.WriteLine();
            Console.WriteLine("            Steal:");
            Console.WriteLine();
            Console.WriteLine($"                Steals {AllEnemyStatistics.Goblin.StealAmount} gold from the player and adds it to his Goldstash.");
            Console.WriteLine("                 After defeating the Golbin, he will be dropping a random amount of gold wich will be chosen between the base gold and the gold that the goblin has stolen.");
            Console.WriteLine();
            Console.WriteLine("     Assassin:");
            Console.WriteLine();
            Console.WriteLine($"        Health: {AllEnemyStatistics.Assassin.BaseHealth}");
            Console.WriteLine($"        Attack: {AllEnemyStatistics.Assassin.BaseAttack}");
            Console.WriteLine($"        Armor: {AllEnemyStatistics.Assassin.BaseArmor}");
            Console.WriteLine($"        Strength: {AllEnemyStatistics.Assassin.Strength}");
            Console.WriteLine($"        EXP: {AllEnemyStatistics.Assassin.BaseEXP}");
            Console.WriteLine($"        Gold: {AllEnemyStatistics.Assassin.Gold}");
            Console.WriteLine($"        Special Attacks:");
            Console.WriteLine();
            Console.WriteLine("            Backstab:");
            Console.WriteLine();
            Console.WriteLine($"                Deals double damage to the player abd ignores your defence.");
            Console.WriteLine();
            Console.WriteLine("     Stone Golem:");
            Console.WriteLine();
            Console.WriteLine($"        Can't defend");
;            Console.WriteLine();
            Console.WriteLine($"        Health: {AllEnemyStatistics.StoneGolem.BaseHealth}");
            Console.WriteLine($"        Attack: {AllEnemyStatistics.StoneGolem.BaseAttack}");
            Console.WriteLine($"        Armor: {AllEnemyStatistics.StoneGolem.BaseArmor}");
            Console.WriteLine($"        Strength: {AllEnemyStatistics.StoneGolem.Strength}");
            Console.WriteLine($"        EXP: {AllEnemyStatistics.StoneGolem.BaseEXP}");
            Console.WriteLine($"        Gold: {AllEnemyStatistics.StoneGolem.Gold}");
            Console.WriteLine($"        Special Attacks:");
            Console.WriteLine();
            Console.WriteLine("            Slam:");
            Console.WriteLine();
            Console.WriteLine($"                Deals damage to the player and has a {AllEnemyStatistics.StoneGolem.StunChance}% chance to stun the player.");
            Console.WriteLine($"                Stun prevents the player from attacking for the next turn.");
            Console.WriteLine();
            Console.WriteLine("     Demonic Sorcerer (Mini Boss):");
            Console.WriteLine();
            Console.WriteLine($"        Health: {AllEnemyStatistics.DemonicSorcerer.BaseHealth}");
            Console.WriteLine($"        Attack: {AllEnemyStatistics.DemonicSorcerer.BaseAttack}");
            Console.WriteLine($"        Armor: {AllEnemyStatistics.DemonicSorcerer.BaseArmor}");
            Console.WriteLine($"        Strength: {AllEnemyStatistics.DemonicSorcerer.Strength}");
            Console.WriteLine($"        EXP: {AllEnemyStatistics.DemonicSorcerer.BaseEXP}");
            Console.WriteLine($"        Gold: {AllEnemyStatistics.DemonicSorcerer.Gold}");
            Console.WriteLine($"        Special Attacks:");
            Console.WriteLine();
            Console.WriteLine("            Hellfire Blast:");
            Console.WriteLine();
            Console.WriteLine($"                Deals damage to the player and has a {AllEnemyStatistics.DemonicSorcerer.BurnChance}% chance to burn the player.");
            Console.WriteLine($"                Burn deals {AllEnemyStatistics.DemonicSorcerer.BurnDamage} base damage for {GameSettings.EffectDurations.Burn} turns.");
            Console.WriteLine();
            Console.WriteLine("            Soulsteal:");
            Console.WriteLine();
            Console.WriteLine($"                Deals damage to the player and heals the sorcerer for half the damage dealt.");
            Console.WriteLine();
            Console.WriteLine("            Dark Pact:");
            Console.WriteLine();
            Console.WriteLine($"                Gains {AllEnemyStatistics.DemonicSorcerer.DarkPacktAttackPercentage * 100}%. attack damage for {AllEnemyStatistics.DemonicSorcerer.DarkPacktHealthPercentage * 100}% of his health.");
            Console.WriteLine();
            Console.WriteLine("     Giant Spider (Mini Boss):");
            Console.WriteLine();
            Console.WriteLine($"        Health: {AllEnemyStatistics.GiantSpider.BaseHealth}");
            Console.WriteLine($"        Attack: {AllEnemyStatistics.GiantSpider.BaseAttack}");
            Console.WriteLine($"        Armor: {AllEnemyStatistics.GiantSpider.BaseArmor}");
            Console.WriteLine($"        Strength: {AllEnemyStatistics.GiantSpider.Strength}");
            Console.WriteLine($"        EXP: {AllEnemyStatistics.GiantSpider.BaseEXP}");
            Console.WriteLine($"        Gold: {AllEnemyStatistics.GiantSpider.Gold}");
            Console.WriteLine($"        Special Attacks:");
            Console.WriteLine();
            Console.WriteLine("            Poison Bite:");
            Console.WriteLine();
            Console.WriteLine($"                Deals damage to the player and has a {AllEnemyStatistics.GiantSpider.PoisonChance}% chance to poison the player.");
            Console.WriteLine($"                Poison deals {AllEnemyStatistics.GiantSpider.BasePoisonDamage} base damage for {GameSettings.EffectDurations.Poison} turns.");
            Console.WriteLine();
            Console.WriteLine("            Webshot:");
            Console.WriteLine();
            Console.WriteLine($"                Deals damage to the player and has a {AllEnemyStatistics.GiantSpider.StunChance}% chance to stun the player.");
            Console.WriteLine($"                Stun prevents the player from attacking for the next turn.");
            Console.WriteLine();
            Console.WriteLine("     Dragon (Boss):");
            Console.WriteLine();
            Console.WriteLine($"        Health: {AllEnemyStatistics.Dragon.BaseHealth}");
            Console.WriteLine($"        Attack: {AllEnemyStatistics.Dragon.BaseAttack}");
            Console.WriteLine($"        Armor: {AllEnemyStatistics.Dragon.BaseArmor}");
            Console.WriteLine($"        Strength: {AllEnemyStatistics.Dragon.Strength}");
            Console.WriteLine($"        EXP: {AllEnemyStatistics.Dragon.BaseEXP}");
            Console.WriteLine($"        Gold: {AllEnemyStatistics.Dragon.Gold}");
            Console.WriteLine($"        Special Attacks:");
            Console.WriteLine();
            Console.WriteLine("            Fire Breath:");
            Console.WriteLine();
            Console.WriteLine($"                Deals damage to the player and has a {AllEnemyStatistics.Dragon.BurnChance}% chance to burn the player.");
            Console.WriteLine($"                Burn deals {AllEnemyStatistics.Dragon.BurnDamage} base damage for {GameSettings.EffectDurations.Burn} turns.");
            Console.WriteLine();
            Console.WriteLine("            Rockthrow:");
            Console.WriteLine();
            Console.WriteLine($"                Deals damage to the player and has a {AllEnemyStatistics.Dragon.StunChance}% chance to stun the player.");
            Console.WriteLine($"                Stun prevents the player from attacking for the next turn.");
            Console.WriteLine();
            Console.WriteLine("            Tailstrike:");
            Console.WriteLine();
            Console.WriteLine($"                Deals double damage and ignores players defence.");
            WaitForInput();
        }
    }
}
