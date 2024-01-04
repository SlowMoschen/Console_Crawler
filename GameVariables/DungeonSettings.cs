using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Crawler.GameVariables
{
    internal class DungeonSettings
    {
        private static Random random = new Random();

        public static string[] EnemyTypes { get; } = { "Zombie", "Spider", "Goblin", "Assassin", "Stone Golem" };
        public static string[] MiniBossTypes { get; } = { "Giant Spider", "Demonic Sorcerer" };
        public static int MiniBossSpawnRate { get; } = 25;
        public static int EasyRooms { get; } = 1;
        public static int MediumRooms { get; } = 2;
        public static int HardRooms { get; } = 3;
        public static int BossRooms { get; } = 5;
        public static int EasyMobs => random.Next(1, 4);
        public static int MediumMobs => random.Next(3, 6);
        public static int HardMobs => random.Next(5, 11);
        public static int BossMobs => random.Next(10, 21);
        public static int GetChestItemsLength(string difficulty) => difficulty switch
        {
            "Easy" => 1,
            "Medium" => random.Next(2, 4),
            "Hard" => random.Next(3, 5),
            "Boss" => random.Next(4, 6),
            _ => 0
        };
        public static int GetChestGold(string difficulty) => difficulty switch
        {
            "Easy" => random.Next(5, 11),
            "Medium" => random.Next(10, 21),
            "Hard" => random.Next(20, 31),
            "Boss" => random.Next(30, 81),
            _ => 0
        };
        public static string[] ChestItems { get; } = { "Heal Potion", "Strength Potion", "Endurance Potion" };
        public static string[] ChestWeapons { get; } = { "Sword", "Axe", "Mace" };
    }
}
