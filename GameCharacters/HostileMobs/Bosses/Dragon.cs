using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder;

namespace Console_Crawler.GameCharacters.HostileMobs.Bosses
{
    internal class Dragon : Enemy
    {
        public int FireBreathDamage { get; set; }
        public int RockThrowDamage { get; set; }
        public int TailStrikeDamage { get; set; }
        public new DragonStatistics EnemyStats { get; set; }
        public Dragon(string name, int EXP, int Gold, DragonStatistics enemyStatistics) : base(name, EXP, Gold, enemyStatistics)
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
        }

        //Fire Breath - Has a chance to burn the player
        private void FireBreathAttack(Player target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength, this.FireBreathDamage);

            if (target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                return;
            }
            else
            {
                target.Health -= damage;

                if (Randomizer.GetChance(this.EnemyStats.BurnChance))
                {
                    target.Effects.IsBurning = true;
                    target.EffectTurns.BurnTurns = 3;
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
                return;
            }
            else
            {
                target.Health -= damage;

                if (Randomizer.GetChance(this.EnemyStats.StunChance))
                {
                    target.Effects.IsStunned = true;
                }
            }
        }

        //Tail Strike - Ignores Players Defense
        private void TailStrikeAttack(Player target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength, this.TailStrikeDamage);

            if (target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                target.Health -= damage;
                return;
            }
            else
            {
                target.Health -= damage;
            }
        }
    }
}
