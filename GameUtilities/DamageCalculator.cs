using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Crawler.GameVariables;

namespace Console_Crawler.GameUtilities
{
    internal class DamageCalculator
    {
        public static int CalculateAttackDamage(int attackDamage, int targetArmor, double strength, int specialAttackDamage = 0)
        {
            return (int)((int)((attackDamage + specialAttackDamage) * strength) * (1 - CalculateDamageReduction(targetArmor)));
        }

        public static double CalculateDamageReduction(int targetArmor)
        {
            return (double)(targetArmor / (targetArmor + GameSettings.General.DamageReductionRate));
        }
    }
}
