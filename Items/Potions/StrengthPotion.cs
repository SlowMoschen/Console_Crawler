using Console_Crawler.GameVariables;

namespace Console_Crawler.Items.Potions
{
    internal class StrengthPotion : Potion
    {
        public StrengthPotion() : base("", "", "", 0, ItemSettings.ItemMaxQuantity.StrengthPotion, 0)
        {
            EffectValue = ItemSettings.ItemEffect.StrengthPotion;
            Price = ItemSettings.ItemPrice.Potions.StrengthPotion;
            Name = "Strength Potion";
            Description = "Your next attacks will deal double the damage";
            Type = "Potion";
        }
    }
}
