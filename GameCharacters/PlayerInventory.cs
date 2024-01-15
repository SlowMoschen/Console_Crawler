using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables;
using Console_Crawler.Items;
using Console_Crawler.Items.Potions;

namespace Console_Crawler.GameCharacters
{
    internal class PlayerInventory
    {
        public List<Item> Items { get; set; }
        public int Gold { get; set; }

        public PlayerInventory()
        {
            Items = new List<Item>();
            Gold = 0;
        }

        public Item? GetExistingItem(string itemName)
        {
            return this.Items.FirstOrDefault(i => i.Name == itemName);
        }

        public void AddItem(Item item)
        {
            var existingItem = GetExistingItem(item.Name);

            if(existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                this.Items.Add(item);
            }
        }

        public void RemoveItem(Item item)
        {
            var existingItem = GetExistingItem(item.Name);

            if(existingItem != null)
            {
                existingItem.Quantity--;

                if(existingItem.Quantity <= 0)
                {
                    this.Items.Remove(existingItem);
                }
            }
        }

        public Item GetRandomItem()
        {
            int randomIndex = Randomizer.GetRandomNumber(this.Items.Count);
            return this.Items[randomIndex];
        }

        public string[] GetAllItemsCount()
        {
            List<string> items = new List<string>();

            foreach(var item in this.Items)
            {
                items.Add(GetItemQuantity(item.Name).ToString());
            }

            return items.ToArray();
        }

        public string[] GetAllItemsNames()
        {
            List<string> items = new List<string>();

            foreach(var item in this.Items)
            {
                items.Add(item.Name);
            }

            return items.ToArray();
        }

        public string[] GetAllItemsTypes()
        {
            List<string> items = new List<string>();

            foreach(var item in this.Items)
            {
                items.Add(item.Type);
            }

            return items.ToArray();
        }

        public int GetItemQuantity(string itemType)
        {
            var existingItem = GetExistingItem(itemType);

            if(existingItem != null)
            {
                return existingItem.Quantity;
            }

            return 0;
        }

        public void AddGold(int amount)
        {
            this.Gold += amount;
        }

        public void RemoveGold(int amount = 0)
        {
            if(GameBools.RanAway)
            {
                this.Gold /= 2;
                return;
            }

            if(this.Gold - amount >= 0)
            {
                this.Gold -= amount;
            }
            else
            {
                this.Gold = 0;
            }
        }

        public void DisplayInventory()
        {
            Console.WriteLine($"     Gold: {this.Gold}");

            foreach(var item in this.Items)
            {
                Console.WriteLine($"     {item.Name}: {item.Quantity}");
            }
        }

        public string CalculateMaxPotionsPurchaseable(Item item)
        {
            int maxItems = 0;

            if(this.Gold >= item.Price)
            {
                maxItems = this.Gold / item.Price;
            }

            if(maxItems > item.MaxQuantity)
            {
                maxItems = item.MaxQuantity;
            }

            int currentPotions = this.GetItemQuantity(item.Type);

            if(maxItems > 0 && currentPotions + maxItems > item.MaxQuantity)
            {
                maxItems = item.MaxQuantity - currentPotions;
            }

            return maxItems.ToString();
        }
    }
}
