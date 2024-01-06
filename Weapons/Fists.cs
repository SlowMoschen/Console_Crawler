﻿using Console_Crawler.GameVariables.Statistics.WeaponStatistics;

namespace Console_Crawler.Weapons
{
    internal class Fists : Weapon
    {
        public Fists() : base(WeaponStats.Fists, "Fists")
        {
            SetBaseAttackDamage();
            SetSpecialAttackDamage();
        }
    }
}
