using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics;
using Console_Crawler.Items;

namespace Console_Crawler.GameCharacters.HostileMobs.MiniBosses
{
    internal class GoblinKing : Enemy
    {
        public new GoblinKingStatistics EnemyStats { get; set; }
        public int StealAmount { get; set; }
        public bool IsEnraged { get; set; } = false;

        public GoblinKing(string name, GoblinKingStatistics enemyStatistics) : base(name, enemyStatistics)
        {
            this.EnemyStats = enemyStatistics;
            this.StealAmount = enemyStatistics.StealAmount;
            this.SetStats();
            this.SpecialAttacks =
            [
                ("Enrage", Enrage),
                ("Treasure Drain", TreasureDrain),
                ("Golden Barrage", GoldenBarrage)
            ];
        }

        public override void ResetBuffedStats()
        {
            this.Attack = this.EnemyStats.BaseAttack;
            this.Armor = this.EnemyStats.BaseArmor;
            this.IsEnraged = false;
        }

        public override void PrintBattleStats()
        {
            base.PrintBattleStats();

            if(this.IsEnraged)
            {
                Console.WriteLine($" Enraged for {this.EffectTurns.BuffedTurns} turns");
            }
        }

        private void Enrage(Player target)
        {
            // if the Goblin King is already enraged, get another random action
            // Performanceissues because recursion?
            if(this.IsEnraged)
            {
                EnemyAction enemyAction = this.GetRandomAction();
                this.ExecuteAction(target, enemyAction);
                return;
            }
            this.Attack += EnemyStats.EnrageExtraAttack;
            this.Armor += EnemyStats.EnrageExtraArmor;
            this.IsEnraged = true;
            this.EffectTurns.BuffedTurns = EnemyStats.EnragedTurns;
            Console.WriteLine($" The Goblin King is enraged! He gains {EnemyStats.EnrageExtraAttack} Attack and {EnemyStats.EnrageExtraArmor} Armor for {EnemyStats.EnragedTurns} turns!");
        }

        private void TreasureDrain(Player target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength);

            if (target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                Console.WriteLine($" {this.Name} tried to attack you, but you successfully defended the damage!");
            }
            else
            {
                target.Health -= damage;
                this.DealtDamage = damage;
                GameStatistics.AddTotalDamageTaken(damage);
                Console.WriteLine($" {this.Name} used Treasure Drain at you for {damage} damage.");
            }

            if (target.Inventory.Gold >= this.StealAmount)
            {
                target.Inventory.RemoveGold(this.StealAmount);
                this.Gold += this.StealAmount;
                Console.WriteLine($" The Goblin King stole {this.StealAmount} Gold from you!");
            }
            else
            {
                Console.WriteLine(" The Goblin King found no Gold to steal!");
            }

            if (Randomizer.GetChance(this.EnemyStats.ItemStealChance))
            {
                if (target.Inventory.Items.Count > 0)
                {
                    Item item = target.Inventory.GetRandomItem();
                    target.Inventory.RemoveItem(item);
                    Console.WriteLine($" The Goblin King stole your {item.Name}!");
                }
                else
                {
                    Console.WriteLine(" The Goblin King found no Items to steal!");
                }
            }
        }

        // Golden Barrage - Deals damage to the player based on the amount of gold the Goblin King has
        private void GoldenBarrage(Player target)
        {
            int attackDMG = this.Attack + this.Gold / this.EnemyStats.DamageIncreasePerGold; 
            int usedGold = this.Gold / this.EnemyStats.BarrageGoldDecrease;
            this.Gold -= usedGold;
            int damage = DamageCalculator.CalculateAttackDamage(attackDMG, target.Armor, this.Strength);

            if(target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                Console.WriteLine($" {this.Name} tried to use Golden Barrage on you, but you successfully defended the damage!");
                return;
            }
            else
            {
                target.Health -= damage;
                this.DealtDamage = damage;
                GameStatistics.AddTotalDamageTaken(damage);
                Console.WriteLine($" {this.Name} used Golden Barrage and throws {usedGold} gold at you for {damage} damage.");
            }
        }

    }
}
