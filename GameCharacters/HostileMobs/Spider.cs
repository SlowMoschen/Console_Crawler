using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics;
using Console_Crawler.GameVariables;

namespace Console_Crawler.GameCharacters.HostileMobs
{
    internal class Spider : Enemy
    {
        public new SpiderStatistics EnemyStats { get; set; }
        public int PoisonDamage { get; set; }
        public Spider(string name, SpiderStatistics enemyStatistics) : base(name, enemyStatistics)
        {
            this.EnemyStats = enemyStatistics;
            this.PoisonDamage = enemyStatistics.BasePoisonDamage;
            this.SetStats();
            this.SpecialAttacks =
            [
                ("Spit", SpitAttack)
            ];
        }

        public override void SetStats()
        {
            base.SetStats();
            this.PoisonDamage = CalculateStat(this.EnemyStats.BasePoisonDamage, GameSettings.EnemyScaling.PoisonScaling, GameSettings.EnemyScaling.ScalingIntervals.PoisonInterval);
        }

        private void SpitAttack(Player target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength);

            if (target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                return;
            }
            else
            {
                this.DealtDamage = damage;  
                target.Health -= damage;
                if (Randomizer.GetChance(this.EnemyStats.PoisonChance))
                {
                    target.Effects.IsPoisoned = true;
                    target.EffectTurns.PoisonTurns = 3;
                }
            }
        }
    }
}
