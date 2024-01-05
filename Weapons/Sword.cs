using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Crawler.GameVariables.Statistics.WeaponStatistics;

namespace Console_Crawler.Weapons
{
    internal class Sword : Weapon
    {
        public Sword() : base(WeaponStats.Sword, "Sword")
        {
            SetBaseAttackDamage();
            SetSpecialAttackDamage();
        }
    }
}
