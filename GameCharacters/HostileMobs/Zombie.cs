using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder;

namespace Console_Crawler.GameCharacters.HostileMobs
{
    internal class Zombie : Enemy
    {
        public Zombie(string name, int EXP, int Gold, EnemyStatistics enemyStatistics) : base(name, EXP, Gold, enemyStatistics) 
        {
            SpecialAttacks = new List<(string Name, Action<Player> Attack)>
            {
                ("Bite", BiteAttack),
                ("Thrash", ThrashAttack)
            };
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
                target.Health -= damage;
                this.Health -= damage / 4;
            }
        }
    }
}
