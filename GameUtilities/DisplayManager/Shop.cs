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
            DisplaySubHeader("Shop");
            Console.WriteLine(" Inventory:");
            player.PrintInventory();
            Console.WriteLine();
            DisplayMaximumItemsQuantity();

            string itemChoice = GetShopItemChoice(player);

            if(itemChoice == "Go Back")
            {
                DisplayShopMenu(player);
                return;
            }

            int itemQuantityChoice = GetItemQuantityChoice(player, itemChoice);

            for(int i = 1; i <= itemQuantityChoice; i++) 
            {
                // create new Instance of Item to avoid to double the quantity of the item
                Item item = GenerateItem(itemChoice);

                int existingItemQuantity = player.Inventory.GetItemQuantity(item.Type);  
                if(existingItemQuantity >= item.MaxQuantity)
                {
                    Console.WriteLine($" You can't buy more than {item.MaxQuantity} {item.Name}s.");
                    break;
                }

                if(player.Inventory.Gold >= item.Price)
                {
                    player.BuyItem(item);
                    Console.WriteLine($" You bought a {item.Name} for {item.Price} gold.");
                }
                else
                {
                    Console.WriteLine(" You don't have enough gold to buy this item.");
                    break;
                }
            }
            WaitForInput();
            DisplayBuyingShop(player);
        }


        private static void DisplayMaximumItemsQuantity()
        {
            Console.WriteLine($" You can carry a maximum of {ItemSettings.ItemMaxQuantity.StrengthPotion} Strength Potions.");
            Console.WriteLine($" You can carry a maximum of {ItemSettings.ItemMaxQuantity.HealPotion} Heal and Endurance Potions.");    
        }

        private static string GetShopItemChoice(Player player)
        {
            string[] allItemPrices = ItemSettings.ItemPrice.GetAllItemPrices();
            return DisplayOptionsMenu("What would you like to buy?", MenuOptions.ShopItems, allItemPrices);
        }

        private static Item GenerateItem(string itemChoice)
        {
            switch (itemChoice)
            {
                case "Heal Potion":
                    return new HealPotion();
                case "Strength Potion":
                    return new StrengthPotion();
                case "Endurance Potion":
                    return new EndurancePotion();
                default:
                    return null;
            }
        }

        private static int GetItemQuantityChoice(Player player, string itemChoice)
        {
            string itemQuantityChoice = DisplayOptionsMenu("How many would you like to buy?", new string[] { "1", "2", "3", "Maximum"});
            Item item = GenerateItem(itemChoice);
            
            if(itemQuantityChoice == "Maximum")
            {
                itemQuantityChoice = player.Inventory.CalculateMaxPotionsPurchaseable(item);
                Console.WriteLine($" You will buy {itemQuantityChoice} of {item.Name}.");
                WaitForInput();
            }
            
            return Int32.Parse(itemQuantityChoice);
        }
    }
}
