using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder;

namespace Console_Crawler.GameCharacters.HostileMobs.MiniBosses
{
    internal class GiantSpider : Enemy
    {
        public new GiantSpiderStatistics EnemyStats { get; set; }
        public int PoisonDamage { get; set; }
        public int PoisonBiteDamage { get; set; }
        public int WebShotDamage { get; set; }
        public GiantSpider(string name, GiantSpiderStatistics enemyStatistics) : base(name, enemyStatistics)
        {
            this.EnemyStats = enemyStatistics;
            this.SetStats();
            SpecialAttacks =
            [
                ("Poison Bite", PoisonBiteAttack),
                ("Webshot", WebShotAttack)
            ];
        }

        public override void SetStats()
        {
            base.SetStats();
            this.PoisonBiteDamage = CalculateStat(this.EnemyStats.BasePoisonBiteDamage, GameSettings.EnemyScaling.AttackScaling, GameSettings.EnemyScaling.ScalingIntervals.AttackInterval);
            this.WebShotDamage = CalculateStat(this.EnemyStats.BaseWebShotDamage, GameSettings.EnemyScaling.AttackScaling, GameSettings.EnemyScaling.ScalingIntervals.AttackInterval);
            this.PoisonDamage = CalculateStat(this.EnemyStats.BasePoisonDamage, GameSettings.EnemyScaling.PoisonScaling, GameSettings.EnemyScaling.ScalingIntervals.PoisonInterval);
        }

        private void PoisonBiteAttack(Player target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength, this.PoisonBiteDamage);

            if (target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                return;
            }
            else
            {
                target.Health -= damage;

                if (Randomizer.GetChance(this.EnemyStats.PoisonChance))
                {
                    target.Effects.IsPoisoned = true;
                    target.EffectTurns.PoisonTurns = 3;
                }
            }
        }

        private void WebShotAttack(Player target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength, this.WebShotDamage);

            if (target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                return;
            }
            else
            {
                target.Health -= damage;
                
                if (Randomizer.GetChance(this.EnemyStats.StunChance))
                {
                    target.Effects.IsStunned = true;
                }
            }
        }
    }
}
