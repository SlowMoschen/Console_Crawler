using Console_Crawler.GameCharacters;

namespace Console_Crawler.GameUtilities.DisplayManager
{
    internal partial class DisplayManager
    {
        public static void DisplayCurrentInventory(Player player)
        {
            Console.WriteLine();
            Console.WriteLine(" Inventory:");
            Console.WriteLine();
            player.PrintInventory();
            Console.WriteLine();
            Console.WriteLine(" Weapon:");
            player.CurrentWeapon.DisplayWeaponStats();
        }

        public static void DisplayUsingInventory(Player player)
        {
            Console.Clear();
            DisplayHeader("Use Item");
            player.PrintStats();

            if(player.Inventory.Items.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine(" You don't have any items.");
                WaitForInput();
                return;
            }

            DisplayUsableItemsAndUseIt(player);
        }

        private static void DisplayUsableItemsAndUseIt(Player player)
        {
            string itemChoice = player.ChoosePotion();

            switch (itemChoice)
            {
                case "Heal Potion":
                    player.UsePotion("Health Potion");
                    break;
                case "Strength Potion":
                    player.UsePotion("Strength Potion");
                    break;
                case "Endurance Potion":
                    player.UsePotion("Endurance Potion");
                    break;
                default:
                    DisplayInventoryMenu(player);
                    break;
            }
        }
    }
}
