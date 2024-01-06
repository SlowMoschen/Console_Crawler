using Console_Crawler.GameUtilities;
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
                return;
            }
            else
            {
                target.Health -= damage;
                if (Randomizer.GetChance(EnemyStats.StunChance))
                {
                    target.Effects.IsStunned = true;
                }
            }
        }
    }
}
