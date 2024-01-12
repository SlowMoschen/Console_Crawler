using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables;
using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder;

namespace Console_Crawler.GameCharacters.HostileMobs.MiniBosses
{
    internal class DemonicSorcerer : Enemy
    {
        public new DemonicSorcererStatistics EnemyStats { get; set; }
        public int HellFireBlastDamage { get; set; }
        public int BurnDamage { get; set; }

        public DemonicSorcerer(string name, DemonicSorcererStatistics enemyStatistics) : base(name, enemyStatistics)
        {
            this.EnemyStats = enemyStatistics;
            this.SetStats();
            this.SpecialAttacks =
            [
                ("Hellfire Blast", HellFireBlastAttack),
                ("Soulsteal", Soulsteal),
                ("Dark Pact", DarkPact)
            ];
        }

        public override void SetStats()
        {
            base.SetStats();
            this.HellFireBlastDamage = CalculateStat(this.EnemyStats.BaseHellFireBlastDamage, GameSettings.EnemyScaling.AttackScaling, GameSettings.EnemyScaling.ScalingIntervals.AttackInterval);
            this.BurnDamage = CalculateStat(this.EnemyStats.BurnDamage, GameSettings.EnemyScaling.BurnScaling, GameSettings.EnemyScaling.ScalingIntervals.BurnInterval);
        }

        // Fireball - Has a chance to burn the player
        private void HellFireBlastAttack(Player target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength, this.HellFireBlastDamage);

            if (target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                Console.WriteLine($" {this.Name} tried to use its Hellfire Blast on you, but you successfully defended the attack!");
                return;
            }
            else
            {
                GameStatistics.AddTotalDamageDealt(damage);
                this.DealtDamage = damage;
                target.Health -= damage;
                Console.WriteLine($" {this.Name} used its Hellfire Blast on you for {damage} damage.");

                if (Randomizer.GetChance(this.EnemyStats.BurnChance))
                {
                    target.Effects.IsBurning = true;
                    target.EffectTurns.BurnTurns = GameSettings.EffectDurations.Burn;
                    Console.WriteLine($" {this.Name} set you on fire for {GameSettings.EffectDurations.Burn} turns!");
                }
            }
        }

        // Soulsteal - Deals damage to the player and heals the sorcerer for half the damage dealt
        private void Soulsteal(Player target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength);

            if (target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                Console.WriteLine($" {this.Name} tried to use its Soulsteal on you, but you successfully defended the attack!");
                return;
            }
            else
            {
                GameStatistics.AddTotalDamageDealt(damage);
                this.DealtDamage = damage;
                target.Health -= damage;
                this.Health += damage / 2;
                Console.WriteLine($" {this.Name} used its Soulsteal on you for {damage} damage and healed itself for {damage / 2} health.");
            }
        }

        // Dark Pact - Increases the sorcerers attack by 20% and decreases its health by 10%
        private void DarkPact(Player target)
        {
            this.Attack += (int)(this.Attack * this.EnemyStats.DarkPacktAttackPercentage);
            this.Health -= (int)(this.Health * this.EnemyStats.DarkPacktHealthPercentage);
            Console.WriteLine($" {this.Name} used its Dark Pact and increased its attack by {this.EnemyStats.DarkPacktAttackPercentage * 100}% and decreased its health by {this.EnemyStats.DarkPacktHealthPercentage * 100}%.");
            Console.WriteLine($" {this.Name} now has {this.Health} health and {this.Attack} attack.");
        }
    }
}
