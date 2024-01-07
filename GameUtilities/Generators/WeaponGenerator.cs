using Console_Crawler.GameVariables;
using Console_Crawler.Weapons;

namespace Console_Crawler.GameUtilities.Generators
{
    internal class WeaponGenerator
    {
        public static Weapon GenerateRandomChestWeapon()
        {
            string[] weaponTypes = DungeonSettings.ChestWeapons;
            string weaponType = weaponTypes[Randomizer.GetRandomNumber(weaponTypes.Length)];

            switch (weaponType)
            {
                case "Sword":
                    return new Sword();
                case "Axe":
                    return new Axe();
                case "Mace":
                    return new Mace();
                default:
                    return new Sword();
            }
        }

        public static Weapon GenerateWeaponByChoice( string choice ) => choice switch
        {
            "Sword" => new Sword(),
            "Axe" => new Axe(),
            "Mace" => new Mace(),
            _ => new Sword()
        };
    }
}
