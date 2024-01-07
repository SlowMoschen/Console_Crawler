using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Crawler.GameCharacters;
using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables;
using Console_Crawler.GameVariables.Statistics.PlayerStatistics;
using Console_Crawler.GameVariables.Statistics.WeaponStatistics;

namespace Console_Crawler.Weapons
{
    internal class Weapon
    {
        private static Random random = new Random();
        public WeaponStats WeaponStats { get; set; }
        public int AttackDamage { get; set; }
        public int SpecialAttackDamage { get; set; }
        public string WeaponName { get; set; }

        public Weapon(WeaponStats weaponStats, string weaponName)
        {
            this.WeaponStats = weaponStats;
            this.WeaponName = weaponName;
            SetBaseAttackDamage();
            SetSpecialAttackDamage();
        }

        public void SetBaseAttackDamage()
        {
            this.AttackDamage = CalculateAttackDamage(this.WeaponStats.MinBaseDamage, this.WeaponStats.MaxBaseDamage, this.WeaponStats.MinMultiplier, this.WeaponStats.MaxMultiplier);
        }

        public void SetSpecialAttackDamage()
        {
            this.SpecialAttackDamage = CalculateAttackDamage(this.WeaponStats.MinSpecialDamage, this.WeaponStats.MaxSpecialDamage, this.WeaponStats.MinMultiplier, this.WeaponStats.MaxMultiplier);
        }

        public static int CalculateAttackDamage(int minDamage, int maxDamage, int minMultiplier, int maxMultiplier)
        {
            int playerLevel = PlayerStats.Level;
            int interval = GameSettings.General.WeaponUpgradeInterval;
            int min = minDamage + ((playerLevel - 1) / interval) * minMultiplier;
            int max = maxDamage + ((playerLevel - 1) / interval) * maxMultiplier;

            return random.Next(min, max + 1);
        }

        public void PerformSpecialAttack(Player player, GameCharacter target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.AttackDamage, target.Armor, player.Strength, this.SpecialAttackDamage);

            if(player.Endurance >= this.WeaponStats.SpecialEnduranceCost)
            {
                if(target.Effects.IsDefending)
                {
                    target.Effects.IsDefending = false;
                    return;
                }
                else
                {
                    target.Effects.IsDefending = true;
                    target.Health -= damage;
                    player.Endurance -= this.WeaponStats.SpecialEnduranceCost;
                }
            }
            else
            {
                Console.WriteLine(" You don't have enough endurance to use your Special Attack!");
            }
        }
    }
}
