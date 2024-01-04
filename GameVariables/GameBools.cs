using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Crawler.GameVariables
{
    internal class GameBools
    {
        public static bool IsGameRunning { get; set; } = false;
        public static bool IsDead { get; set; } = false;
        public static bool IsInBattle { get; set; } = false;
        public static bool IsInShop { get; set; } = false;
        public static bool IsInMenu { get; set; } = false;
        public static bool IsDungeonCleared { get; set; } = false;
        public static bool RanAway { get; set; } = false;
    }
}
