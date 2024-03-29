﻿namespace Console_Crawler.GameUtilities
{
    internal class Randomizer
    {
        private static Random random = new Random();


        // @param min: the minimum number to return
        // @param max: the maximum number to return
        // @return a random number between min and max
        public static int GetRandomNumber(int max, int min = 0)
        {
            return random.Next(min, max);
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
