using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder
{
    internal class GoblinStatistics : EnemyStatistics
    {
        public int StealAmount { get; set; }
        public GoblinStatistics(int baseAttack, int baseArmor, double strength, int baseHealth, int baseEXP, int Gold, int stealAmount) : base(baseAttack, baseArmor, strength, baseHealth, baseEXP, Gold)
        {
            StealAmount = stealAmount;
        }
    }
}
