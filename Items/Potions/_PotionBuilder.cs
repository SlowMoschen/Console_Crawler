using Console_Crawler.GameCharacters;
using Console_Crawler.GameVariables.Statistics;

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
                GameStatistics.AddTotalItemUsed();

                switch (Name)
                {
                    case "Health Potion":
                        target.Health += EffectValue;

                        if (target.Health > target.MaxHealth)
                        {
                            target.Health = target.MaxHealth;
                        }
                        break;
                    case "Strength Potion":
                        target.Strength += EffectValue;
                        break;
                    case "Endurance Potion":
                        target.Endurance += EffectValue;

                        if (target.Endurance > target.MaxEndurance)
                        {
                            target.Endurance = target.MaxEndurance;
                        }
                        break;
                }
            }
        }
    }
}
