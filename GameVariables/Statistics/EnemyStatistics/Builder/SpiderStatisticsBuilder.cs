namespace Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder
{
    internal class SpiderStatistics : EnemyStatistics
    {
        public int BasePoisonDamage { get; set; }
        public int PoisonChance { get; set; }
        public SpiderStatistics(int baseAttack, int baseArmor, double strength, int baseHealth, int baseEXP, int Gold, int basePoisonDamage, int poisonChance) : base(baseAttack, baseArmor, strength, baseHealth, baseEXP, Gold)
        {
            BasePoisonDamage = basePoisonDamage;
            PoisonChance = poisonChance;
        }
    }
}
