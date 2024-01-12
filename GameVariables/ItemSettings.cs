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
            public static int HealPotion { get; } = 15;
            public static int StrengthPotion { get; } = 35;
            public static int EndurancePotion { get; } = 25;

            //Method to store all the prices in an array
            public static string[] GetAllItemPrices()
            {
                PropertyInfo[] properties = typeof(ItemPrice).GetProperties();

                List<string> prices = new List<string>();
                foreach (PropertyInfo property in properties) {
                   prices.Add(property.GetValue(null).ToString() + "G");
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
