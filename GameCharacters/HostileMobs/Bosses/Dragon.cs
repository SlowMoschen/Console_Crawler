using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables;
using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder;

namespace Console_Crawler.GameCharacters.HostileMobs.Bosses
{
    internal class Dragon : Enemy
    {
        public int FireBreathDamage { get; set; }
        public int RockThrowDamage { get; set; }
        public int TailStrikeDamage { get; set; }
        public int BurnDamage { get; set; }
        public new DragonStatistics EnemyStats { get; set; }
        public Dragon(string name, DragonStatistics enemyStatistics) : base(name, enemyStatistics)
        {
            this.EnemyStats = enemyStatistics;
            this.SetStats();
            SpecialAttacks =
            [
                ("Fire Breath", FireBreathAttack),
                ("Rock Throw", RockThrowAttack),
                ("Tailstrike", TailStrikeAttack)
            ];
        }

        public override void SetStats()
        {
            base.SetStats();
            this.FireBreathDamage = this.EnemyStats.FireBreathDamage;
            this.RockThrowDamage = this.EnemyStats.RockThrowDamage;
            this.TailStrikeDamage = this.EnemyStats.TailStrikeDamage;
            this.BurnDamage = this.EnemyStats.BurnDamage;
        }

        //Fire Breath - Has a chance to burn the player
        private void FireBreathAttack(Player target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength, this.FireBreathDamage);

            if (target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                Console.WriteLine($" {this.Name} tried to use its fire breath on you, but you successfully defended the attack!");
                return;
            }
            else
            {
                GameStatistics.AddTotalDamageDealt(damage);
                this.DealtDamage = damage;
                target.Health -= damage;
                Console.WriteLine($" {this.Name} used its fire breath on you for {damage} damage.");

                if (Randomizer.GetChance(this.EnemyStats.BurnChance))
                {
                    target.Effects.IsBurning = true;
                    target.EffectTurns.BurnTurns = GameSettings.EffectDurations.Burn;
                    Console.WriteLine($" {this.Name} set you on fire for {GameSettings.EffectDurations.Burn} turns!");
                }
            }
        }

        //Rock Throw - Has a chance to stun the player
        private void RockThrowAttack(Player target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength, this.RockThrowDamage);

            if (target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                Console.WriteLine($" {this.Name} tried to throw a rock at you, but you successfully defended the attack!");
                return;
            }
            else
            {
                GameStatistics.AddTotalDamageDealt(damage);
                this.DealtDamage = damage;
                target.Health -= damage;
                Console.WriteLine($" {this.Name} threw a rock at you for {damage} damage.");

                if (Randomizer.GetChance(this.EnemyStats.StunChance))
                {
                    target.Effects.IsStunned = true;
                    Console.WriteLine($" {this.Name} stunned you!");
                }
            }
        }

        //Tail Strike - Ignores Players Defense
        private void TailStrikeAttack(Player target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength, this.TailStrikeDamage);
            this.DealtDamage = damage;

            if (target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                this.DealtDamage = damage;
                target.Health -= damage;
                GameStatistics.AddTotalDamageDealt(damage);
                Console.WriteLine($" You tried to defend the {this.Name}'s Tailstrike, but it was to fast and dealt {damage} damage.");
                return;
            }
            else
            {
                GameStatistics.AddTotalDamageDealt(damage);
                this.DealtDamage = damage;
                target.Health -= damage;
                Console.WriteLine($" {this.Name} used a Tailstrike on you for {damage} damage.");
            }
        }
    }
}
