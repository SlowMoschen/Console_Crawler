using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Crawler.GameVariables
{
    internal class ItemSettings
    {
        internal class ItemMaxQuantity
        {
            public static int HealPotion { get; } = 5;
            public static int StrengthPotion { get; } = 3;
            public static int EndurancePotion { get; } = 5;
        }

        internal class ItemPrice
        {
            public static int HealPotion { get; } = 15;
            public static int StrengthPotion { get; } = 35;
            public static int EndurancePotion { get; } = 25;
        }

        internal class ItemEffect
        {
            public static int HealPotion => 40 + (int)Math.Pow(1, 2);
            public static int StrengthPotion { get; } = 2;
            public static int EndurancePotion { get; } = 50;
        }
    }
}
