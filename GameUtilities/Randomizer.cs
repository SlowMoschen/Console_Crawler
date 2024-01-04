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

        public int GetRandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }


        // @param percent: a number between 0 and 100
        // @return true if the random number is less than or equal to the percent
        public bool GetChance(double percent)
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
