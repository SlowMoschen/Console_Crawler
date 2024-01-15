using Console_Crawler.GameVariables;

namespace Console_Crawler.Items.Potions
{
    internal class HealthPotion : Potion
    {
        public HealthPotion() : base("", "", "", 0, ItemSettings.ItemMaxQuantity.HealPotion, 0)
        {
            this.EffectValue = ItemSettings.ItemEffect.HealPotion;
            this.Price = ItemSettings.ItemPrice.Potions.HealPotion;
            this.Name = "Health Potion";
            this.Description = $"Heals the player for {this.EffectValue} health.";
            this.Type = "Potion";
            this.Quantity = 1;
        }
    }
}
