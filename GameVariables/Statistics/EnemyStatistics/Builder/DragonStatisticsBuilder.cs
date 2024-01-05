using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder
{
    internal class DragonStatistics : EnemyStatistics
    {
        int FireBreathDamage { get; set; }
        int BurnDamage { get; set; }
        int BurnChance { get; set; }
        int RockThrowDamage { get; set; }
        int StunChance { get; set; }
        int TailStrikeDamage { get; set; }

        public DragonStatistics(int baseAttack, int baseArmor, double strength, int baseHealth, int baseEXP, int Gold, int fireBreathDamage, int burnDamage, int burnChance, int rockThrowDamage, int stunChance, int tailStrikeDamage) : base(baseAttack, baseArmor, strength, baseHealth, baseEXP, Gold)
        {
            FireBreathDamage = fireBreathDamage;
            BurnDamage = burnDamage;
            BurnChance = burnChance;
            RockThrowDamage = rockThrowDamage;
            StunChance = stunChance;
            TailStrikeDamage = tailStrikeDamage;
        }
    }
}
