using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Crawler.GameVariables
{
    internal class GameStatistics
    {
        public static string Version { get; } = "0.0.1";
        public static int SurviedRooms { get; set; } = 0;
        public static int SurviedDungeons { get; set; } = 0;
        public static int KilledEnemies { get; set; } = 0;
        public static int TotalEXP { get; set; } = 0;
        public static int TotalGold { get; set; } = 0;
    }
}
