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
