using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder;

namespace Console_Crawler.GameCharacters.HostileMobs
{
    internal class StoneGolem : Enemy
    {
        public new StoneGolemStatistics EnemyStats { get; set; }
        public StoneGolem(string name, StoneGolemStatistics enemyStatistics) : base(name, enemyStatistics)
        {
            EnemyStats = enemyStatistics;
            this.SetStats();
            SpecialAttacks =
            [
                ("Slam", SlamAttack)
            ];
        }

        private void SlamAttack(Player target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(Attack, target.Armor, Strength);

            if (target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                Console.WriteLine($" {this.Name} tried to attack you, but you successfully defended the attack!");
                return;
            }
            else
            {
                GameStatistics.AddTotalDamageDealt(damage);
                this.DealtDamage = damage;
                target.Health -= damage;
                Console.WriteLine($" {this.Name} used its Slam attack for {damage} damage.");
                if (Randomizer.GetChance(EnemyStats.StunChance))
                {
                    target.Effects.IsStunned = true;
                    Console.WriteLine($" {this.Name} stunned you!");
                }
            }
        }
    }
}
