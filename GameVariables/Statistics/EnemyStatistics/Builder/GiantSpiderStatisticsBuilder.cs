namespace Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder
{
    internal class GiantSpiderStatistics : SpiderStatistics
    {
        public int BaseWebShotDamage { get; set; }
        public int StunChance { get; set; }
        public int BasePoisonBiteDamage { get; set; }
        public GiantSpiderStatistics(int baseAttack, int baseArmor, double strength, int baseHealth, int baseEXP, int Gold, int basePoisonDamage, int poisonChance, int baseWebShotDamage, int stunChance, int basePoisonBiteDamage) : base(baseAttack, baseArmor, strength, baseHealth, baseEXP, Gold, basePoisonDamage, poisonChance)
        {
            BaseWebShotDamage = baseWebShotDamage;
            StunChance = stunChance;
            BasePoisonBiteDamage = basePoisonBiteDamage;
        }
    }
}
