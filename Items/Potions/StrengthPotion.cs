using Console_Crawler.GameVariables;

namespace Console_Crawler.Items.Potions
{
    internal class StrengthPotion : Potion
    {
        public StrengthPotion() : base("", "", "", 0, 0, 0)
        {
            EffectValue = ItemSettings.ItemEffect.StrengthPotion;
            MaxQuantity = ItemSettings.ItemMaxQuantity.StrengthPotion;
            Price = ItemSettings.ItemPrice.StrengthPotion;
            Name = "Strength Potion";
            Description = "Your next attacks will deal double the damage";
            Type = "Strength Potion";
        }
    }
}
