using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Crawler.GameVariables;

namespace Console_Crawler.Weapons
{
    internal class Fists : WeaponBuilder
    {
        public Fists() : base(WeaponStats.Fists, "Fists")
        {
            SetBaseAttackDamage();
            SetSpecialAttackDamage();
        }
    }
}
