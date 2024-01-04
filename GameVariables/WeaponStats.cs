using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Crawler.GameVariables
{
    internal class WeaponStats(int minBaseDamage, int maxBaseDamage, int minSpecialDamage, int maxSpecialDamage, int minMultiplier, int maxMultiplier, int enduranceCost, int specialEnduranceCost, string? specialAttackName)
    {
        public int MinBaseDamage { get; set; } = minBaseDamage;
        public int MaxBaseDamage { get; set; } = maxBaseDamage;
        public int MinSpecialDamage { get; set; } = minSpecialDamage;
        public int MaxSpecialDamage { get; set; } = maxSpecialDamage;
        public int MinMultiplier { get; set; } = minMultiplier;
        public int MaxMultiplier { get; set; } = maxMultiplier;
        public int EnduranceCost { get; set; } = enduranceCost;
        public int SpecialEnduranceCost { get; set; } = specialEnduranceCost;
        public string? SpecialAttackName { get; set; } = specialAttackName;

        public static WeaponStats Sword = new WeaponStats(
            minBaseDamage: 27,
            maxBaseDamage: 32,
            minSpecialDamage: 40,
            maxSpecialDamage: 45,
            minMultiplier: 15,
            maxMultiplier: 18,
            enduranceCost: 18,
            specialEnduranceCost: 25,
            specialAttackName: "Slash"
            );

        public static WeaponStats Axe = new WeaponStats(
            minBaseDamage: 38,
            maxBaseDamage: 43,
            minSpecialDamage: 55,
            maxSpecialDamage: 60,
            minMultiplier: 17,
            maxMultiplier: 20,
            enduranceCost: 25,
            specialEnduranceCost: 45,
            specialAttackName: "Chop"
            );

        public static WeaponStats Mace = new WeaponStats(
            minBaseDamage: 32,
            maxBaseDamage: 38,
            minSpecialDamage: 45,
            maxSpecialDamage: 50,
            minMultiplier: 16,
            maxMultiplier: 18,
            enduranceCost: 22,
            specialEnduranceCost: 28,
            specialAttackName: "Bash"
            );

        public static WeaponStats Fists = new WeaponStats(
               minBaseDamage: 5,
               maxBaseDamage: 10,
               minSpecialDamage: 15,
               maxSpecialDamage: 20,
               minMultiplier: 5,
               maxMultiplier: 10,
               enduranceCost: 5,
               specialEnduranceCost: 10,
               specialAttackName: "Punch"
            );
    }
}
