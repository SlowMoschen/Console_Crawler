namespace Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder
{
    internal class DemonicSorcererStatistics : EnemyStatistics
    {
        public int BaseHellFireBlastDamage { get; set; }
        public int BurnDamage { get; set; }
        public int BurnChance { get; set; }
        public double DarkPacktAttackPercentage { get; set; }
        public double DarkPacktHealthPercentage { get; set; }
        public DemonicSorcererStatistics(int baseAttack, int baseArmor, double strength, int baseHealth, int baseEXP, int Gold, int baseHellFireBlastDamage, int burnDamage, int burnChance, double darkPacktAttackPercentage, double darkPacktHealthPercentage) : base(baseAttack, baseArmor, strength, baseHealth, baseEXP, Gold)
        {
            BaseHellFireBlastDamage = baseHellFireBlastDamage;
            BurnDamage = burnDamage;
            BurnChance = burnChance;
            DarkPacktAttackPercentage = darkPacktAttackPercentage;
            DarkPacktHealthPercentage = darkPacktHealthPercentage;
        }
    }
}
