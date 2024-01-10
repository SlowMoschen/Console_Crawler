namespace Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder
{
    internal class EnemyStatistics(int baseAttack, int baseArmor, double strength, int baseHealth, int baseEXP, int Gold)
    {
        public int BaseAttack { get; set; } = baseAttack;
        public int BaseArmor { get; set; } = baseArmor;
        public double Strength { get; set; } = strength;
        public int BaseHealth { get; set; } = baseHealth;
        public int BaseEXP { get; set; } = baseEXP;
        public int Gold { get; set; } = Gold;

    }
}
