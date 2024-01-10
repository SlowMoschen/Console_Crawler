using Console_Crawler.GameVariables;
using Console_Crawler.GameVariables.Statistics.PlayerStatistics;
using Console_Crawler.GameVariables.Statistics.WeaponStatistics;
using Console_Crawler.Weapons;
using NUnit.Framework;

namespace Console_Crawler.GameCharacters.__tests__
{
    [TestFixture]
    internal class Player_Test
    {
        [Test]
        public void Player_Constructor_Test()
        {
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            Assert.That(player.Name, Is.EqualTo("TestPlayer"));
            Assert.That(player.Attack, Is.EqualTo(PlayerStats.InitialAttack));
            Assert.That(player.Armor, Is.EqualTo(PlayerStats.InitialArmor));
            Assert.That(player.Strength, Is.EqualTo(PlayerStats.InitialStrength));
            Assert.That(player.Health, Is.EqualTo(PlayerStats.InitialHealth));
            Assert.That(player.MaxHealth, Is.EqualTo(PlayerStats.InitialMaxHealth));
            Assert.That(player.Endurance, Is.EqualTo(100));
            Assert.That(player.MaxEndurance, Is.EqualTo(100));
            Assert.That(player.CurrentWeapon, Is.InstanceOf(typeof(Fists)));
            Assert.That(player.Inventory, Is.InstanceOf(typeof(PlayerInventory)));
        }

        [Test]
        public void Player_EquipWeapon_Test()
        {
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);
            Weapon weapon = new Weapon(new WeaponStats(1, 2, 1, 2, 1, 2, 1, 2, "Special Attack"), "TestWeapon");

            player.EquipWeapon(weapon);

            Assert.That(player.CurrentWeapon, Is.EqualTo(weapon));
        }

        [Test]
        public void Player_EquipWeapon_Override_OldWeapon_Test()
        {
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);
            Weapon weapon = new Weapon(new WeaponStats(1, 2, 1, 2, 1, 2, 1, 2, "Special Attack"), "TestWeapon");
            Weapon weapon2 = new Weapon(new WeaponStats(2, 3, 2, 3, 2, 3, 2, 3, "Special Attack"), "TestWeapon2");

            player.EquipWeapon(weapon);
            player.EquipWeapon(weapon2);

            Assert.That(player.CurrentWeapon, Is.EqualTo(weapon2));
        }

        [Test]
        public void Player_SetAttackOptions_Test()
        {
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            player.SetAttackOptions();

            Assert.That(MenuOptions.AttackOptions[0], Is.EqualTo("Normal Attack"));
            Assert.That(MenuOptions.AttackOptions[1], Is.EqualTo(player.CurrentWeapon.WeaponStats.SpecialAttackName));
            Assert.That(MenuOptions.AttackOptions[2], Is.EqualTo("Kick Attack"));
        }

        [Test]
        public void Player_DecrementBuffTurns_Test()
        {
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);
            player.EffectTurns.StrenghtBuffTurns = 1;
            player.Strength = 10;

            player.DecrementBuffTurns();

            Assert.That(player.EffectTurns.StrenghtBuffTurns, Is.EqualTo(0));
            Assert.That(player.Strength, Is.EqualTo(PlayerStats.InitialStrength));
        }

        [Test]
        public void Player_Rest_Test()
        {
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);
            player.Health = 50;
            player.Endurance = 50;

            player.Rest();

            Assert.That(player.Health, Is.EqualTo(50 + GameSettings.General.RestHealthRegen));
            Assert.That(player.Endurance, Is.EqualTo(50 + GameSettings.General.RestEnduranceRegen));
        }

        [Test]
        public void Player_NormalAttack_Test()
        {
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);
            GameCharacter target = new GameCharacter("TestTarget", 0, 0, 0, 100);

            player.NormalAttack(target);

            Assert.That(target.Health, Is.EqualTo(100 - player.CurrentWeapon.AttackDamage));
        }

        [Test]
        public void Player_NormalAttack_NotEnoughEnduracne_Test()
        {
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);
            GameCharacter target = new GameCharacter("TestTarget", 0, 0, 0, 100);
            player.Endurance = 0;

            player.NormalAttack(target);

            Assert.That(target.Health, Is.EqualTo(100));
        }

        [Test]
        public void Player_UseSpecialAttack_Test()
        {
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);
            GameCharacter target = new GameCharacter("TestTarget", 0, 0, 0, 100);

            player.UseSpecialAttack(target);

            Assert.That(target.Health, Is.LessThan(100));
        }

        [Test]
        public void Player_UseSpecialAttack_NotEnoughEndurance_Test()
        {
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);
            GameCharacter target = new GameCharacter("TestTarget", 0, 0, 0, 100);
            player.Endurance = 0;

            player.UseSpecialAttack(target);

            Assert.That(target.Health, Is.EqualTo(100));
        }

        [Test]
        public void Player_LevelUp_Test()
        {
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            player.EXP = 100;
            player.LevelUp();

            Assert.That(player.EXP, Is.EqualTo(0));
            Assert.That(player.Level, Is.EqualTo(2));
            Assert.That(player.MaxHealth, Is.EqualTo(PlayerStats.InitialMaxHealth * player.Level));
            Assert.That(player.Health, Is.EqualTo(player.MaxHealth));
            Assert.That(player.Armor, Is.EqualTo(PlayerStats.InitialArmor + LevelUpModifers.Armor));
            Assert.That(player.Attack, Is.EqualTo(PlayerStats.InitialAttack + LevelUpModifers.Attack));
            Assert.That(PlayerStats.Level, Is.EqualTo(2));

            PlayerStats.ResetPlayerStats(); 
        }

        [Test]
        public void Player_AddEXP_Test()
        {
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            player.AddEXP(50);

            Assert.That(player.EXP, Is.EqualTo(50));
        }
    }
}
