using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder
{
    internal class DemonicSorcererStatistics : EnemyStatistics
    {
        int HellFireBlastDamage { get; set; }
        int BurnDamage { get; set; }
        int BurnChance { get; set; }
        double DarkPacktAttackPercentage { get; set; }
        double DarkPacktHealthPercentage { get; set; }
        public DemonicSorcererStatistics(int baseAttack, int baseArmor, double strength, int baseHealth, int baseEXP, int Gold, int hellFireBlastDamage, int burnDamage, int burnChance, double darkPacktAttackPercentage, double darkPacktHealthPercentage) : base(baseAttack, baseArmor, strength, baseHealth, baseEXP, Gold)
        {
            HellFireBlastDamage = hellFireBlastDamage;
            BurnDamage = burnDamage;
            BurnChance = burnChance;
            DarkPacktAttackPercentage = darkPacktAttackPercentage;
            DarkPacktHealthPercentage = darkPacktHealthPercentage;
        }
    }
}
