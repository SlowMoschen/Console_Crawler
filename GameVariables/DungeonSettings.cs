using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public static int ItemSpawnRate { get; } = 25;
        public static int WeaponSpawnRate { get; } = 25;
        public static int GetRoomCount(string difficulty) => difficulty switch
        {
            "Easy" => 1,
            "Medium" => 2,
            "Hard" => 3,
            "Boss" => 5,
            "Dev" => 1,
            _ => 0
        };
        public static int GetRoomEnemiesCount(string difficulty) => difficulty switch
        {
            "Easy" => random.Next(1, 4),
            "Medium" => random.Next(3, 6),
            "Hard" => random.Next(5, 11),
            "Boss" => random.Next(10, 21),
            "Dev" => 1,
            _ => 0
        };
        public static int GetChestItemsLength(string difficulty) => difficulty switch
        {
            "Easy" => 1,
            "Medium" => random.Next(2, 4),
            "Hard" => random.Next(3, 5),
            "Boss" => random.Next(4, 6),
            "Dev" => 5,
            _ => 0
        };
        public static int GetChestGold(string difficulty) => difficulty switch
        {
            "Easy" => random.Next(5, 11),
            "Medium" => random.Next(10, 21),
            "Hard" => random.Next(20, 31),
            "Boss" => random.Next(30, 81),
            "Dev" => 1000,
            _ => 0
        };
        public static string[] ChestItems { get; } = { "Heal Potion", "Strength Potion", "Endurance Potion" };
        public static string[] ChestWeapons { get; } = { "Sword", "Axe", "Mace" };
    }
}
