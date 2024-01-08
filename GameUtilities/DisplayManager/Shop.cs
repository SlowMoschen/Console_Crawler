using Console_Crawler.GameCharacters;
using Console_Crawler.GameVariables;
using Console_Crawler.Items;
using Console_Crawler.Items.Potions;

namespace Console_Crawler.GameUtilities.DisplayManager
{
    internal partial class DisplayManager
    {
        public static void DisplayBuyingShop(Player player)
        {
            Console.Clear();
            DisplayHeader("Shop");
            Console.WriteLine(" Inventory:");
            player.PrintInventory();
            Console.WriteLine();
            DisplayMaximumItemsQuantity();
            Item itemChoice = GetItemChoice(player);
            int itemQuantityChoice = GetItemQuantityChoice(player, itemChoice);

            for(int i = 0; i < itemQuantityChoice; i++)
            {
                if(player.Inventory.Gold >= itemChoice.Price)
                {
                    player.Inventory.AddItem(itemChoice);
                    player.Inventory.Gold -= itemChoice.Price;
                }
                else
                {
                    Console.WriteLine(" You don't have enough gold to buy this item.");
                    break;
                }
            }
        }


        private static void DisplayMaximumItemsQuantity()
        {
            Console.WriteLine($" You can carry a maximum of {ItemSettings.ItemMaxQuantity.StrengthPotion} Strength Potions.");
            Console.WriteLine($" You can carry a maximum of {ItemSettings.ItemMaxQuantity.HealPotion} Heal and Endurance Potions.");    
        }

        private static Item GetItemChoice(Player player)
        {
            string itemChoice = DisplayOptionsMenu("What would you like to buy?", MenuOptions.ShopItems);

            switch (itemChoice)
            {
                case "Heal Potion":
                    return new HealPotion();
                case "Strength Potion":
                    return new StrengthPotion();
                case "Endurance Potion":
                    return new EndurancePotion();
                case "Exit":
                    DisplayShopMenu(player);
                    return null;
                default:
                    return new HealPotion();
            }
        }

        private static int GetItemQuantityChoice(Player player, Item item)
        {
            string itemQuantityChoice = DisplayOptionsMenu("How many would you like to buy?", new string[] { "1", "2", "3", "Maximum"});
            
            if(itemQuantityChoice == "Maximum")
            {
                itemQuantityChoice = player.Inventory.CalculateMaxPotionsPurchaseable(item);
            }
            
            return Int32.Parse(itemQuantityChoice);
        }
    }
}
