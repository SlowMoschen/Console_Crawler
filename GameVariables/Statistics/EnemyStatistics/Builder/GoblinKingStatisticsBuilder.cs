using Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder;

namespace Console_Crawler.GameVariables.Statistics.EnemyStatistics
{
    internal class GoblinKingStatistics : GoblinStatistics
    {
        public int EnrageExtraAttack { get; set; }
        public int EnrageExtraArmor { get; set; }
        public int EnragedTurns { get; set; }
        public double ItemStealChance { get; set; }
        public int DamageIncreasePerGold { get; set; }
        public int BarrageGoldDecrease { get; set; }

        public GoblinKingStatistics(int baseAttack, int baseArmor, double strength, int baseHealth, int baseEXP, int Gold, int stealAmount, int enrageExtraAttack, int enrageExtraArmor, int enragedTurns, double itemStealChance, int damageIncreasePerGold, int barrageGoldDecrease ) : base(baseAttack, baseArmor, strength, baseHealth, baseEXP, Gold, stealAmount)
        {
            this.EnrageExtraAttack = enrageExtraAttack;
            this.EnrageExtraArmor = enrageExtraArmor;
            this.EnragedTurns = enragedTurns;
            ItemStealChance = itemStealChance;
            DamageIncreasePerGold = damageIncreasePerGold;
            BarrageGoldDecrease = barrageGoldDecrease;
        }
    }
}
