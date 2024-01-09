using Console_Crawler.GameCharacters;
using Console_Crawler.GameUtilities;
using Console_Crawler.GameUtilities.DisplayManager;
using Console_Crawler.GameUtilities.Generators;
using Console_Crawler.GameVariables;
using Console_Crawler.Items;
using Console_Crawler.Items.Potions;
using Console_Crawler.Weapons;
using System.Numerics;


namespace Console_Crawler.DungeonBuilder
{
    internal class Chest
    {
        public int Gold { get; set; }
        public Item[]? Items { get; set; }
        public Weapon? Weapons { get; set; }

        public Chest(string diffficulty)
        {
            this.Gold = DungeonSettings.GetChestGold(diffficulty);
            this.Items = Randomizer.GetChance(100) ? GenerateChestItems(diffficulty) : null;
            this.Weapons = Randomizer.GetChance(DungeonSettings.WeaponSpawnRate) ? GenerateChestWeapon() : null;
        }

        private static int GetChestItemsLength(string difficulty)
        {
            return DungeonSettings.GetChestItemsLength(difficulty);
        }

        private static Item[] GenerateChestItems(string difficulty)
        {
            int itemsCount = GetChestItemsLength(difficulty);
            Item[] items = new Item[itemsCount];

            for (int i = 0; i < itemsCount; i++)
            {
                items[i] = GetChestItem();
            }

            return items;
        }

        private static Item GetChestItem()
        {
            string[] chestItems = DungeonSettings.ChestItems;
            string chestItem = chestItems[Randomizer.GetRandomNumber(chestItems.Length)];

            switch (chestItem)
            {
                case "Heal Potion":
                    return new HealPotion();
                case "Strength Potion":
                    return new StrengthPotion();
                case "Endurance Potion":
                    return new EndurancePotion();
                default:
                    return new HealPotion();
            }
        }

        private static Weapon GenerateChestWeapon()
        {
            return WeaponGenerator.GenerateRandomChestWeapon();
        }

        public void OpenChest(Player player)
        {
           Console.WriteLine(" You have found a chest!");
           Console.WriteLine();
           Console.WriteLine($" You found {this.Gold} Gold in this Chest!");
           player.Inventory.AddGold(this.Gold);

           if(this.Items != null)
           {
                ItemsFoundInChest(player);
           }

           if(this.Weapons != null)
           {
                WeaponFoundInChest(player);
           }

        }

        private void ItemsFoundInChest(Player player)
        {
            Console.WriteLine(" You found some items in this chest!");
            foreach (Item item in this.Items)
            {
                DisplayManager.AddChestItemsToInventory(player, item);
            }
        }

        private void WeaponFoundInChest(Player player)
        {
            Console.WriteLine(" You found a weapon in this chest!");
            DisplayManager.AskToEquipWeapon(player, this.Weapons);
        }

    }
}
