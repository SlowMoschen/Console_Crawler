﻿using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics;

namespace Console_Crawler.GameCharacters.HostileMobs
{
    internal class Spider : Enemy
    {
        public new SpiderStatistics EnemyStats { get; set; }
        public Spider(string name, int EXP, int Gold, SpiderStatistics enemyStatistics) : base(name, EXP, Gold, enemyStatistics)
        {
            this.EnemyStats = enemyStatistics;
            this.SpecialAttacks =
            [
                ("Spit", SpitAttack)
            ];
        }

        public void SpitAttack(Player target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength);

            if (target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                return;
            }
            else
            {
                target.Health -= damage;
                if (Randomizer.GetChance(this.EnemyStats.PoisonChance))
                {
                    target.Effects.IsPoisoned = true;
                    target.EffectTurns.PoisonTurns = 3;
                }
            }
        }
    }
}
