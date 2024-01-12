using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables.Statistics;
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
                Console.WriteLine($" {this.Name} tried to use a Bite attack on you, but you successfully defended the attack!");
                return;
            }
            else
            {
                GameStatistics.AddTotalDamageDealt(damage);
                this.DealtDamage = damage;
                target.Health -= damage;
                this.Health += damage / 2;
                Console.WriteLine($" {this.Name} used Bite on you for {damage} damage and healed itself for {damage / 2} health.");
            }
        }

        // Thrash Attack - Deals damage to the player and a quater of the dealt damage to the zombie itself
        private void ThrashAttack(Player target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength);

            if(target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                Console.WriteLine($" {this.Name} tried to use a Thrash attack on you, but you successfully defended the attack!");
                return;
            }
            else
            {
                GameStatistics.AddTotalDamageDealt(damage);
                this.DealtDamage = damage;
                target.Health -= damage;
                this.Health -= damage / 4;
                Console.WriteLine($" {this.Name} used Thrash on you for {damage} damage and took {damage / 4} damage itself.");
            }
        }
    }
}
