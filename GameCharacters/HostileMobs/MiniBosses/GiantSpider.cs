using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables;
using Console_Crawler.GameVariables.Statistics;
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
                Console.WriteLine($" {this.Name} tried to use its poison bite on you, but you successfully defended the attack!");
                return;
            }
            else
            {
                GameStatistics.AddTotalDamageDealt(damage);
                this.DealtDamage = damage;
                target.Health -= damage;
                Console.WriteLine($" {this.Name} used its poison bite on you for {damage} damage.");

                if (Randomizer.GetChance(this.EnemyStats.PoisonChance))
                {
                    target.Effects.IsPoisoned = true;
                    target.EffectTurns.PoisonTurns = GameSettings.EffectDurations.Poison;
                    Console.WriteLine($" {this.Name} poisoned you for {GameSettings.EffectDurations.Poison} turns!");
                }
            }
        }

        private void WebShotAttack(Player target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength, this.WebShotDamage);

            if (target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                Console.WriteLine($" {this.Name} tried to use its webshot on you, but you successfully defended the attack!");
                return;
            }
            else
            {
                GameStatistics.AddTotalDamageDealt(damage);
                this.DealtDamage = damage;
                target.Health -= damage;
                Console.WriteLine($" {this.Name} used its webshot on you for {damage} damage.");
                
                if (Randomizer.GetChance(this.EnemyStats.StunChance))
                {
                    target.Effects.IsStunned = true;
                    Console.WriteLine($" {this.Name} stunned you!");
                }
            }
        }
    }
}
