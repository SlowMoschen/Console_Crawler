using Console_Crawler.GameVariables.Statistics.WeaponStatistics;

namespace Console_Crawler.Weapons
{
    internal class Mace : Weapon
    {
        public Mace() : base(WeaponStats.Mace, "Mace")
        {
            SetBaseAttackDamage();
            SetSpecialAttackDamage();
        }
    }
}
