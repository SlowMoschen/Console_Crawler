using Console_Crawler.GameVariables.Statistics.WeaponStatistics;

namespace Console_Crawler.Weapons
{
    internal class Axe : Weapon
    {
        public Axe() : base(WeaponStats.Axe, "Axe")
        {
            SetBaseAttackDamage();
            SetSpecialAttackDamage();
        }
    }
}
