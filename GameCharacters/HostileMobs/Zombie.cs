using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder;

namespace Console_Crawler.GameCharacters.HostileMobs
{
    internal class Zombie : Enemy
    {
        public Zombie(string name, EnemyStatistics enemyStatistics) : base(name, enemyStatistics) 
        {
            this.SetStats();
            SpecialAttacks =
            [
                ("Bite", BiteAttack),
                ("Thrash", ThrashAttack)
            ];
        }

        // Bite Attack - Heals the zombie for half the damage dealt
        private void BiteAttack(Player target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength);

            if(target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                return;
            }
            else
            {
                this.DealtDamage = damage;
                target.Health -= damage;
                this.Health += damage / 2;
            }
        }

        // Thrash Attack - Deals damage to the player and a quater of the dealt damage to the zombie itself
        private void ThrashAttack(Player target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength);

            if(target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                return;
            }
            else
            {
                this.DealtDamage = damage;
                target.Health -= damage;
                this.Health -= damage / 4;
            }
        }
    }
}
