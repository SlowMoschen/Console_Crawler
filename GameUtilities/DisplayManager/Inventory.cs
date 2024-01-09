using Console_Crawler.GameCharacters;
using Console_Crawler.Items;
using Console_Crawler.Weapons;
using NUnit.Framework.Internal.Execution;

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
            DisplaySubHeader("Use Item");
            player.PrintStats();

            if(player.Inventory.Items.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine(" You don't have any items.");
                WaitForInput();
                return;
            }

            DisplayUsableItemsAndUseIt(player);
            WaitForInput();
        }

        private static void DisplayUsableItemsAndUseIt(Player player)
        {
            string itemChoice = GetInventoryItemChoice(player);

            switch (itemChoice)
            {
                case "Health Potion":
                    player.UsePotion("Health Potion");
                    break;
                case "Strength Potion":
                    player.UsePotion("Strength Potion");
                    break;
                case "Endurance Potion":
                    player.UsePotion("Endurance Potion");
                    break;
                case "Go Back":
                    DisplayInventoryMenu(player);
                    break;
                default:
                    DisplayInventoryMenu(player);
                    break;
            }
        }

        private static string GetInventoryItemChoice(Player player)
        {
            string[] itemsCount = player.Inventory.GetAllItemsCount();
            string[] itemNames = player.Inventory.GetAllItemsTypes();

            // add Exit option to the end of the names array
            Array.Resize(ref itemNames, itemNames.Length + 1);
            itemNames[itemNames.Length - 1] = "Go back";

            // add empty string to the end of the count array
            Array.Resize(ref itemsCount, itemsCount.Length + 1);
            itemsCount[itemsCount.Length - 1] = "";

            string itemChoice = DisplayOptionsMenu(" What would you like to buy?", itemNames, itemsCount);

            if (itemChoice == "Go Back")
            {
                DisplayShopMenu(player);
                return "";
            }

            return itemChoice;
        }

        public static void AddChestItemsToInventory(Player player, Item item)
        {
            player.Inventory.AddItem(item);
            Console.WriteLine($" You have added {item.Name} to your Inventory!");
        }

        public static void AskToEquipWeapon(Player player, Weapon weapon)
        {
            Console.WriteLine();
            Console.WriteLine($" You have found a {weapon.WeaponName}!");
            Console.WriteLine();
            Console.WriteLine($" {weapon.WeaponName} Stats:");
            Console.WriteLine();
            weapon.DisplayWeaponStats();
            Console.WriteLine();
            Console.WriteLine(" Your current Weapon Stats:");
            Console.WriteLine();
            player.CurrentWeapon.DisplayWeaponStats();
            Console.WriteLine();

            string answer = InputHandler.GetChoice("Do you want to equip the found Weapon?", new string[] { "Yes", "No" });

            if (answer == "Yes")
            {
                player.EquipWeapon(weapon);
                Console.WriteLine($" You have equipped the {weapon.WeaponName}!");
            }
            else
            {
                Console.WriteLine(" You have left the Weapon in the Chest.");
            }
            
        }
    }
}
