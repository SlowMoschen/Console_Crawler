using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Console_Crawler.GameCharacters;
using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables;
using Console_Crawler.GameVariables.Statistics.WeaponStatistics;

//Unit Tests for Weapon.cs

namespace Console_Crawler.Weapons.__tests__
{
    [TestFixture]
    internal class WeaponBuilder_Test
    {
        //Test to see if AttackDamage is set correctly
        // MinBaseDamage = 1
        // MaxBaseDamage = 2
        // MinMultiplier = 1
        // MaxMultiplier = 2
        // Player.Level = 1
        // Result should be between 1 and 4
        [Test]
        public void CalculateAttackDamage_Test()
        {
            //Arrange
            int minDamage = 1;
            int maxDamage = 2;
            int minMultiplier = 1;
            int maxMultiplier = 2;

            //Act
            int result = Weapons.Weapon.CalculateAttackDamage(minDamage, maxDamage, minMultiplier, maxMultiplier);

            //Assert
            Assert.That(result, Is.InRange(1, 4));
        }

        //Test to see if Endurance is reduced by the SpecialEnduranceCost
        // SpecialEnduranceCost = 5
        // Player.Endurance = 100
        // Player.Endurance should be 95 after the attack
        [Test]
        public void PerformSpecialAttack_Test()
        {
            //Arrange
            Weapons.Weapon weapon = new Weapons.Weapon(new WeaponStats(1, 2, 1, 2, 1, 2, 1, 5, "special"), "TestWeapon");
            Player player = new Player("TestPlayer", 1, 1, 1.0, 1);
            GameCharacter target = new GameCharacter("TestTarget", 1, 1, 1, 1);

            //Act
            weapon.PerformSpecialAttack(player, target);

            //Assert
            Assert.That(player.Endurance, Is.EqualTo(95));
        }
    }
}
