using Console_Crawler.GameCharacters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Crawler.Items
{
    internal class Potion : Item
    {
        public int EffectValue { get; set; }
        public Potion(string name, string type, string description, int price, int maxQuantity, int effectValue) : base(name, type, description, price, maxQuantity)
        {
            this.EffectValue = effectValue;
        }

        public void UsePotion(Player target)
        {
            if(this.Quantity > 0)
            {
                this.Quantity--;

                switch(this.Type)
                {
                    case "Health Potion":
                        target.Health += this.EffectValue;
                        break;
                    case "Strength Potion":
                        target.Strength += this.EffectValue;
                        break;
                    case "Endurance Potion":
                        target.Endurance += this.EffectValue;
                        break;
                }
            }
        }
    }
}
