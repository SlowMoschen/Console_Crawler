using Console_Crawler.GameCharacters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Crawler.Items.Potions
{
    internal class Potion : Item
    {
        public int EffectValue { get; set; }
        public Potion(string name, string type, string description, int price, int maxQuantity, int effectValue) : base(name, type, description, price, maxQuantity)
        {
            EffectValue = effectValue;
        }

        public void UsePotion(Player target)
        {
            if (Quantity > 0)
            {
                Quantity--;

                switch (Type)
                {
                    case "Health Potion":
                        target.Health += EffectValue;
                        break;
                    case "Strength Potion":
                        target.Strength += EffectValue;
                        break;
                    case "Endurance Potion":
                        target.Endurance += EffectValue;
                        break;
                }
            }
        }
    }
}
