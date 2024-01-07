using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Item? GetExistingItem(string itemType)
        {
            return this.Items.FirstOrDefault(i => i.Type == itemType);
        }

        public void AddItem(Item item)
        {
            var existingItem = GetExistingItem(item.Type);

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
            var existingItem = GetExistingItem(item.Type);

            if(existingItem != null)
            {
                existingItem.Quantity -= item.Quantity;

                if(existingItem.Quantity <= 0)
                {
                    this.Items.Remove(existingItem);
                }
            }
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
            Console.WriteLine("Gold: {0}", this.Gold);

            foreach(var item in this.Items)
            {
                Console.WriteLine("{0} x{1}", item.Name, item.Quantity);
            }
        }

        public string CalculateMaxPotionsPurchaseable(Potion potion)
        {
            int maxPotions = 0;

            if(this.Gold >= potion.Price)
            {
                maxPotions = this.Gold / potion.Price;
            }

            if(maxPotions > potion.MaxQuantity)
            {
                maxPotions = potion.MaxQuantity;
            }

            int currentPotions = this.GetItemQuantity(potion.Type);

            if(maxPotions > 0 && currentPotions + maxPotions > potion.MaxQuantity)
            {
                maxPotions = potion.MaxQuantity - currentPotions;
            }

            return maxPotions.ToString();
        }
    }
}
