using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder
{
    internal class GiantSpiderStatistics : SpiderStatistics
    {
        int WebShotDamage { get; set; }
        int StunChance { get; set; }
        int PoisonBiteDamage { get; set; }
        public GiantSpiderStatistics(int baseAttack, int baseArmor, double strength, int baseHealth, int baseEXP, int Gold, int poisonDamage, int poisonChance, int webShotDamage, int stunChance, int poisonBiteDamage) : base(baseAttack, baseArmor, strength, baseHealth, baseEXP, Gold, poisonDamage, poisonChance)
        {
            WebShotDamage = webShotDamage;
            StunChance = stunChance;
            PoisonBiteDamage = poisonBiteDamage;
        }
    }
}
