using Console_Crawler.GameVariables.Statistics.EnemyStatistics;
using Console_Crawler.GameVariables.Statistics.PlayerStatistics;
using NUnit.Framework;

namespace Console_Crawler.GameCharacters.HostileMobs.__tests__
{
    [TestFixture]
    internal class Zombie_Test
    {
        [Test]
        public void Zombie_Constructor_Test()
        {
            Zombie zombie = new Zombie("TestZombie", AllEnemyStatistics.Zombie);

            Assert.That(zombie.Name, Is.EqualTo("TestZombie"));
            Assert.That(zombie.Attack, Is.EqualTo(AllEnemyStatistics.Zombie.BaseAttack));
            Assert.That(zombie.Armor, Is.EqualTo(AllEnemyStatistics.Zombie.BaseArmor));
            Assert.That(zombie.Strength, Is.EqualTo(AllEnemyStatistics.Zombie.Strength));
            Assert.That(zombie.Health, Is.EqualTo(AllEnemyStatistics.Zombie.BaseHealth));
            Assert.That(zombie.Effects.IsDefending, Is.False);
            Assert.That(zombie.Effects.IsStunned, Is.False);
            Assert.That(zombie.Effects.IsPoisoned, Is.False);
            Assert.That(zombie.Effects.IsBurning, Is.False);
            Assert.That(zombie.SpecialAttacks[0].Name, Is.EqualTo("Bite"));
            Assert.That(zombie.SpecialAttacks[1].Name, Is.EqualTo("Thrash"));
        }

        [Test]
        public void Zombie_BiteAttack_Test()
        {
            Zombie zombie = new Zombie("TestZombie", AllEnemyStatistics.Zombie);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            zombie.SpecialAttacks[0].Attack(player);

            Assert.That(player.Health, Is.LessThan(player.MaxHealth));
            Assert.That(zombie.Health, Is.GreaterThan(zombie.EnemyStats.BaseHealth));
        }

        [Test]
        public void Zombie_ThrashAttack_Test()
        {
            Zombie zombie = new Zombie("TestZombie", AllEnemyStatistics.Zombie);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            zombie.SpecialAttacks[1].Attack(player);

            Assert.That(player.Health, Is.LessThan(player.MaxHealth));
            Assert.That(zombie.Health, Is.LessThan(zombie.EnemyStats.BaseHealth));
        }
    }
}
