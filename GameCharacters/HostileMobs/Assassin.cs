using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder;

namespace Console_Crawler.GameCharacters.HostileMobs
{
    internal class Assassin : Enemy
    {
        public Assassin(string name, EnemyStatistics enemyStatistics) : base(name, enemyStatistics)
        {
            this.EnemyStats = enemyStatistics;
            this.SetStats();
            this.SpecialAttacks =
            [
                ("Backstab", BackStabAttack)
            ];
        }

        // Backstab Attack - Deals double damage if and ignores the player's defense if the player is defending
        private void BackStabAttack(Player target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength) * 2;
            this.DealtDamage = damage;

            if (target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                this.DealtDamage = damage;
                target.Health -= damage;
                return;
            }
            else
            {
                GameStatistics.AddTotalDamageDealt(damage);
                this.DealtDamage = damage;
                target.Health -= damage;
            }
        }
    }
}
