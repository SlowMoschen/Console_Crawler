using Console_Crawler.GameCharacters;
using Console_Crawler.GameVariables;
using Console_Crawler.Items;
using Console_Crawler.Items.Potions;

namespace Console_Crawler.GameUtilities.DisplayManager
{
    internal partial class DisplayManager
    {

        private static void DisplayShopMenu( Player player, string shopChoice )
        {
            while (GameBools.IsInShop)
            {
                Console.Clear();
                DisplayHeader(shopChoice);
                GreetPlayerInShop(shopChoice);

                string shopMenuChoice = DisplayOptionsMenu("What would you like to do?", MenuOptions.ShopMenues.ShopMenuOptions);

                switch (shopMenuChoice)
                {
                    case "Buy":

                        if (player.Inventory.Gold < 0)
                        {
                            Console.WriteLine(" You don't have enough gold to buy anything.");
                        }

                        DisplayBuyingShop(player, shopChoice);
                        break;
                    case "Exit Shop":
                        DisplayAllShops(player);
                        break;
                }
            }
        }

        public static void DisplayBuyingShop(Player player, string shopChoice)
        {
            Console.Clear();
            DisplaySubHeader(shopChoice);
            Console.WriteLine(" Inventory:");
            player.PrintInventory();
            Console.WriteLine();
            DisplayMaximumItemsQuantity(shopChoice);

            string itemChoice = GetShopItemChoice(shopChoice);

            if(itemChoice == "Go Back")
            {
                DisplayShopMenu(player, shopChoice);
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
            DisplayBuyingShop(player, shopChoice);
        }

        private static void DisplayRenewalResavoir(Player player, string shopChoice)
        {
            int renewalPrice = ItemSettings.ItemPrice.RenewalResavoir.CalculateRenewalPrice(player);
            Console.Clear();
            DisplayHeader(shopChoice);
            Console.WriteLine();
            GreetPlayerInShop(shopChoice);
            Console.WriteLine();
            Console.WriteLine($" Renewal Price: {renewalPrice} gold");
            Console.WriteLine();
            Console.WriteLine($" Your Gold: {player.Inventory.Gold} gold");
            player.PrintCoreStats();
            
            string itemChoice = GetShopItemChoice(shopChoice);

            if(itemChoice == "Go Back")
            {
                DisplayAllShops(player);
                return;
            }

            if(itemChoice == "Renew Yourself")
            {
                if(player.Health == player.MaxHealth && player.Endurance == player.MaxEndurance)
                {
                    Console.WriteLine(" You are already fully healed and your Endurance is restored.");
                    WaitForInput();
                    DisplayRenewalResavoir(player, shopChoice);
                    return;
                }

                if(player.Inventory.Gold >= renewalPrice)
                {
                    player.Inventory.RemoveGold(renewalPrice);
                    player.Revive();
                    Console.WriteLine(" You have been renewed.");
                }
                else
                {
                    Console.WriteLine(" You don't have enough gold to renew yourself.");
                }
                WaitForInput();
            }

        }

        private static void GreetPlayerInShop(string shopChoice)
        {
            switch (shopChoice)
            {
                case "Talia's Potion Shop":
                    Console.WriteLine();
                    Console.WriteLine(" Welcome to Talia's Potion Shop.");
                    Console.WriteLine(" You can buy potions here.");
                    Console.WriteLine();
                    Console.WriteLine(" Thalia: What can I do for you today?");
                    break;
                case "Galen's Renewal Resavoir":
                    Console.WriteLine();
                    Console.WriteLine(" Welcome to Galen's Renewal Resavoir.");
                    Console.WriteLine(" You can renew yourself here.");
                    Console.WriteLine(" You will be fully healed and your Endurance will be restored.");
                    Console.WriteLine();
                    Console.WriteLine(" Galen: What can I do for you today?");
                    break;
            }
        }

        private static void DisplayMaximumItemsQuantity(string shopChoice)
        {            
            switch (shopChoice)
            {
                case "Talia's Potion Shop":
                    Console.WriteLine($" You can buy a maximum of {ItemSettings.ItemMaxQuantity.HealPotion} Heal Potions.");
                    Console.WriteLine($" You can buy a maximum of {ItemSettings.ItemMaxQuantity.EndurancePotion} Endurance Potions.");
                    Console.WriteLine($" You can buy a maximum of {ItemSettings.ItemMaxQuantity.StrengthPotion} Strength Potions.");
                    break;
                case "Galen's Renewal Resavoir":
                    break;
            }
        }

        private static string GetShopItemChoice(string shopChoice)
        {
            string[] allItemPrices = GetItemPrices(shopChoice);
            string[] allItemNames = GetItemNames(shopChoice);
            return DisplayOptionsMenu("What would you like to get?", allItemNames, allItemPrices);
        }

        private static string[] GetItemNames(string shopChoice)
        {
            switch (shopChoice)
            {
                case "Talia's Potion Shop":
                    return MenuOptions.ShopMenues.PotionShopItems;
                case "Galen's Renewal Resavoir":
                    return MenuOptions.ShopMenues.RenewalResavoirItems;
                default:
                    return null;
            }
        }

        private static string[] GetItemPrices(string shopChoice)
        {
            switch (shopChoice)
            {
                case "Talia's Potion Shop":
                    return ItemSettings.ItemPrice.GetAllItemPrices(typeof(ItemSettings.ItemPrice.Potions));
                case "Galen's Renewal Resavoir":
                    return null;
                default:
                    return null;
            }
        }

        public static Item GenerateItem(string itemChoice)
        {
            switch (itemChoice)
            {
                case "Health Potion":
                    return new HealthPotion();
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
