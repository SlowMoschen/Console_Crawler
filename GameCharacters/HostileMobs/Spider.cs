using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder;
using Console_Crawler.GameVariables;
using Console_Crawler.GameVariables.Statistics;

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
                Console.WriteLine($" {this.Name} tried to Spit at you, but you successfully defended the attack!");
                return;
            }
            else
            {
                GameStatistics.AddTotalDamageDealt(damage);
                this.DealtDamage = damage;  
                target.Health -= damage;
                Console.WriteLine($" {this.Name} Spit at you for {damage} damage.");
                if (Randomizer.GetChance(this.EnemyStats.PoisonChance))
                {
                    Console.WriteLine($" {this.Name} poisoned you for {GameSettings.EffectDurations.Poison} turns!");
                    target.Effects.IsPoisoned = true;
                    target.EffectTurns.PoisonTurns = GameSettings.EffectDurations.Poison;
                }
            }
        }
    }
}
