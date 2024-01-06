using Console_Crawler.GameVariables;

namespace Console_Crawler.Items.Potions
{
    internal class EndurancePotion : Potion
    {
        public EndurancePotion() : base("", "", "", 0, 0, 0)
        {
            EffectValue = ItemSettings.ItemEffect.EndurancePotion;
            MaxQuantity = ItemSettings.ItemMaxQuantity.EndurancePotion;
            Price = ItemSettings.ItemPrice.EndurancePotion;
            Name = "Endurance Potion";
            Description = $"Gives you {this.EffectValue} endurance.";
            Type = "Endurance Potion";
        }
    }
}
