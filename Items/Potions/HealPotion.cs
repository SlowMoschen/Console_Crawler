﻿using Console_Crawler.GameVariables;

namespace Console_Crawler.Items.Potions
{
    internal class HealPotion : Potion
    {
        public HealPotion() : base("", "", "", 0, ItemSettings.ItemMaxQuantity.HealPotion, 0)
        {
            this.EffectValue = ItemSettings.ItemEffect.HealPotion;
            this.Price = ItemSettings.ItemPrice.HealPotion;
            this.Name = "Heal Potion";
            this.Description = $"Heals the player for {this.EffectValue} health.";
            this.Type = "Health Potion";
            this.Quantity = 1;
        }
    }
}