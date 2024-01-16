using Console_Crawler.GameVariables;

namespace Console_Crawler.GameUtilities
{
    internal class DamageCalculator
    {
        public static int CalculateAttackDamage(int attackDamage, int targetArmor, double strength, int specialAttackDamage = 0)
        {
            return (int)((int)((attackDamage + specialAttackDamage) * strength) * (1 - CalculateDamageReduction(targetArmor)));
        }

        // targetArmor and GameSettings.General.DamageReductionRate are both casted to double to avoid integer division
        public static double CalculateDamageReduction(int targetArmor)
        {
            return Math.Round(((double)targetArmor / (targetArmor + (double)GameSettings.General.DamageReductionRate)), 2);
        }
    }
}
