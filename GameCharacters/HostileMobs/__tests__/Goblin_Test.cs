using Console_Crawler.GameVariables.Statistics.EnemyStatistics;
using Console_Crawler.GameVariables.Statistics.PlayerStatistics;
using NUnit.Framework;

namespace Console_Crawler.GameCharacters.HostileMobs.__tests__
{
    [TestFixture]
    internal class Goblin_Test
    {
        [Test]
        public void Goblin_Constructor_Test()
        {
            Goblin goblin = new Goblin("TestGoblin", AllEnemyStatistics.Goblin);

            Assert.That(goblin.Name, Is.EqualTo("TestGoblin"));
            Assert.That(goblin.Attack, Is.EqualTo(AllEnemyStatistics.Goblin.BaseAttack));
            Assert.That(goblin.Armor, Is.EqualTo(AllEnemyStatistics.Goblin.BaseArmor));
            Assert.That(goblin.Strength, Is.EqualTo(AllEnemyStatistics.Goblin.Strength));
            Assert.That(goblin.Health, Is.EqualTo(AllEnemyStatistics.Goblin.BaseHealth));
            Assert.That(goblin.Effects.IsDefending, Is.False);
            Assert.That(goblin.Effects.IsStunned, Is.False);
            Assert.That(goblin.Effects.IsPoisoned, Is.False);
            Assert.That(goblin.Effects.IsBurning, Is.False);
            Assert.That(goblin.SpecialAttacks[0].Name, Is.EqualTo("Steal"));
        }

        // TODO: Fix this test - When i run all Test at once it fails, but when i run it alone it passes

        //[Test]
        //public void Goblin_StealAttack_WithGold_Test()
        //{
        //    Goblin goblin = new Goblin("TestGoblin", AllEnemyStatistics.Goblin);
        //    Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

        //    player.Inventory.AddGold(10);
        //    goblin.SpecialAttacks[0].Attack(player);

        //    Assert.That(player.Inventory.Gold, Is.EqualTo(7));
        //    Assert.That(goblin.Gold, Is.EqualTo(AllEnemyStatistics.Goblin.Gold + AllEnemyStatistics.Goblin.StealAmount));
        //}

        [Test]
        public void Goblin_StealAttack_WithoutGold_Test()
        {
            Goblin goblin = new Goblin("TestGoblin", AllEnemyStatistics.Goblin);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            goblin.SpecialAttacks[0].Attack(player);

            Assert.That(player.Inventory.Gold, Is.EqualTo(0));
        }
    }
}
