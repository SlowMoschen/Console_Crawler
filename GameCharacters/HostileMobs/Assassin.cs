﻿using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder;

namespace Console_Crawler.GameCharacters.HostileMobs
{
    internal class Assassin : Enemy
    {
        public Assassin(string name, int EXP, int Gold, EnemyStatistics enemyStatistics) : base(name, EXP, Gold, enemyStatistics)
        {
            this.EnemyStats = enemyStatistics;
            this.SpecialAttacks =
            [
                ("Backstab", BackStabAttack)
            ];
        }

        // Backstab Attack - Deals double damage if and ignores the player's defense if the player is defending
        private void BackStabAttack(Player target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength);

            if (target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                target.Health -= damage * 2;
                return;
            }
            else
            {
                target.Health -= damage * 2;
            }
        }
    }
}