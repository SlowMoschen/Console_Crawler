using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder;

namespace Console_Crawler.GameCharacters.HostileMobs
{
    internal class Goblin : Enemy
    {
        public int StealAmount { get; set; }
        public new GoblinStatistics EnemyStats { get; set; }
        public Goblin(string name, GoblinStatistics enemyStatistics) : base(name, enemyStatistics)
        {
            this.EnemyStats = enemyStatistics;
            this.StealAmount = enemyStatistics.StealAmount;
            this.SetStats();
            this.SpecialAttacks =
            [
                ("Steal", StealAttack)
            ];
        }

        // Steal Attack - Steals gold from the player
        private void StealAttack(Player target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength);

            if (target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;

                if(target.Inventory.Gold >= this.StealAmount)
                { 
                    target.Inventory.RemoveGold(this.StealAmount);
                }
                else
                {
                    Console.WriteLine(" The Goblin found no Gold to steal!");
                }

                return;
            }
            else
            {
                target.Health -= damage;

                if (target.Inventory.Gold >= this.StealAmount)
                {
                    target.Inventory.RemoveGold(this.StealAmount);
                    this.Gold += this.StealAmount;
                }
                else
                {
                    Console.WriteLine(" The Goblin found no Gold to steal!");
                }
            }
        }
    }
}
