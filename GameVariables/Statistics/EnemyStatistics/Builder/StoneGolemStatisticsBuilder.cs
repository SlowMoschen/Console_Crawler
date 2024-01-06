using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder
{
    internal class StoneGolemStatistics : EnemyStatistics
    {
        public int StunChance { get; set; }
        public StoneGolemStatistics(int baseAttack, int baseArmor, double strength, int baseHealth, int baseEXP, int Gold, int stunChance) : base(baseAttack, baseArmor, strength, baseHealth, baseEXP, Gold)
        {
            StunChance = stunChance;
        }
    }
}
