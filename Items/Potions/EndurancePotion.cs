using Console_Crawler.GameVariables;

namespace Console_Crawler.Items.Potions
{
    internal class EndurancePotion : Potion
    {
        public EndurancePotion() : base("", "", "", 0, ItemSettings.ItemMaxQuantity.EndurancePotion, 0)
        {
            EffectValue = ItemSettings.ItemEffect.EndurancePotion;
            Price = ItemSettings.ItemPrice.Potions.EndurancePotion;
            Name = "Endurance Potion";
            Description = $"Gives you {this.EffectValue} endurance.";
            Type = "Potion";
        }
    }
}
