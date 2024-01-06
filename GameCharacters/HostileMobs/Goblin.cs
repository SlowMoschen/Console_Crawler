using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder;

namespace Console_Crawler.GameCharacters.HostileMobs
{
    internal class Goblin : Enemy
    {
        public int StealAmount { get; set; }
        public new GoblinStatistics EnemyStats { get; set; }
        public Goblin(string name, int EXP, int Gold, GoblinStatistics enemyStatistics) : base(name, EXP, Gold, enemyStatistics)
        {
            this.EnemyStats = enemyStatistics;
            this.StealAmount = enemyStatistics.StealAmount;
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
                target.Inventory.RemoveGold(this.StealAmount);
                return;
            }
            else
            {
                target.Health -= damage;
                target.Inventory.RemoveGold(this.StealAmount);
                this.Gold += this.StealAmount;
            }
        }
    }
}
