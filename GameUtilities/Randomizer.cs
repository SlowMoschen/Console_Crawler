using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Crawler.GameUtilities
{
    internal class Randomizer
    {
        private static Random random = new Random();


        // @param min: the minimum number to return
        // @param max: the maximum number to return
        // @return a random number between min and max
        public static int GetRandomNumber(int min, int max)
        {
            return random.Next(min, max + 1);
        }


        // @param percent: a number between 0 and 100
        // @return true if the random number is less than or equal to the percent
        public static bool GetChance(double percent)
        {
            if(percent < 0 || percent > 100)
            {
                throw new ArgumentOutOfRangeException("Percent must be between 0 and 100");
            }

            double randomPercent = random.NextDouble() * 100;
            return randomPercent <= percent;
        }
    }
}
