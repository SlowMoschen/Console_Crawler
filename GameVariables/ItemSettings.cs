using Console_Crawler.GameCharacters;
using Console_Crawler.GameVariables.Statistics.PlayerStatistics;
using System.Reflection;

namespace Console_Crawler.GameVariables
{
    internal class ItemSettings
    {
        internal class ItemMaxQuantity
        {
            public static int HealPotion { get; } = 10;
            public static int StrengthPotion { get; } = 3;
            public static int EndurancePotion { get; } = 5;
        }

        internal class ItemPrice
        {
            public class Potions
            { 
                public static int HealPotion { get; } = 15;
                public static int StrengthPotion { get; } = 35;
                public static int EndurancePotion { get; } = 25;
            }

            public class RenewalResavoir
            {
                public static int CalculateRenewalPrice(Player player)
                { 
                    int missingHealth = CalculateMissingStat(player.Health, player.MaxHealth);
                    int missingEndurance = CalculateMissingStat(player.Endurance, player.MaxEndurance);

                    return CalculatePotionPrice(missingStat: missingHealth, potionEffect: ItemEffect.HealPotion, potionPrice: Potions.HealPotion) + CalculatePotionPrice(missingStat: missingEndurance, potionEffect: ItemEffect.EndurancePotion, potionPrice: Potions.EndurancePotion) / 2;
                }

                private static int CalculateMissingStat(int currentStat, int maxStat)
                {
                    return maxStat - currentStat;
                }

                private static int CalculatePotionPrice(int missingStat, int potionEffect, int potionPrice)
                {
                    int potionsNeeded = missingStat / potionEffect;
                    return potionsNeeded * potionPrice;
                }
            }

            //Method to store all Item Prices wich are asked for in the Shop
            public static string[] GetAllItemPrices(Type askedPrices)
            {
                PropertyInfo[] properties = askedPrices.GetProperties();

                List<string> prices = new List<string>();
                foreach (PropertyInfo property in properties) {
                   prices.Add(property.GetValue(null, null).ToString() + "G");
                }

                //Add empty String for the Exit option
                prices.Add("");

                return prices.ToArray();
            }
        }

        internal class ItemEffect
        {
            public static int HealPotion => 40 + (int)Math.Pow(PlayerStats.Level, 2);
            public static int StrengthPotion { get; } = 2;
            public static int EndurancePotion { get; } = 50;
        }
    }
}
