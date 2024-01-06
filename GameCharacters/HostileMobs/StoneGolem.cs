using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder;

namespace Console_Crawler.GameCharacters.HostileMobs
{
    internal class StoneGolem : Enemy
    {
        public new StoneGolemStatistics EnemyStats { get; set; }
        public StoneGolem(string name, int EXP, int Gold, StoneGolemStatistics enemyStatistics) : base(name, EXP, Gold, enemyStatistics)
        {
            EnemyStats = enemyStatistics;
            SpecialAttacks =
            [
                ("Slam", SlamAttack)
            ];
        }

        public void SlamAttack(Player target)
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
