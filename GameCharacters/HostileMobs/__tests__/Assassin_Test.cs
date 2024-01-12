using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics;
using Console_Crawler.GameVariables.Statistics.PlayerStatistics;
using NUnit.Framework;

namespace Console_Crawler.GameCharacters.HostileMobs.__tests__
{
    [TestFixture]
    internal class Assassin_Test
    {
        [Test]
        public void Assassin_Constructor_Test()
        {
            Assassin assassin = new Assassin("Assassin", AllEnemyStatistics.Assassin);

            Assert.That(assassin.Name, Is.EqualTo("Assassin"));
            Assert.That(assassin.Attack, Is.EqualTo(AllEnemyStatistics.Assassin.BaseAttack));
            Assert.That(assassin.Armor, Is.EqualTo(AllEnemyStatistics.Assassin.BaseArmor));
            Assert.That(assassin.Strength, Is.EqualTo(AllEnemyStatistics.Assassin.Strength));
            Assert.That(assassin.Health, Is.EqualTo(AllEnemyStatistics.Assassin.BaseHealth));
            Assert.That(assassin.EXP, Is.EqualTo(AllEnemyStatistics.Assassin.BaseEXP));
            Assert.That(assassin.Gold, Is.EqualTo(AllEnemyStatistics.Assassin.Gold));
            Assert.That(assassin.SpecialAttacks[0].Name, Is.EqualTo("Backstab"));
            Assert.That(assassin.Effects.IsDefending, Is.False);
            Assert.That(assassin.Effects.IsStunned, Is.False);
            Assert.That(assassin.Effects.IsPoisoned, Is.False);
            Assert.That(assassin.Effects.IsBurning, Is.False);
        }

        [Test]
        public void Assassin_BackstabAttack_WithOutDefend_Test()
        {
            Assassin assassin = new Assassin("Assassin", AllEnemyStatistics.Assassin);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            assassin.SpecialAttacks[0].Attack(player);

            Assert.That(player.Health, Is.LessThan(player.MaxHealth));
            GameStatistics.ResetGameStatistics();
        }

        [Test]
        public void Assassin_BackstabAttack_WithDefend_Test()
        {
            Assassin assassin = new Assassin("Assassin", AllEnemyStatistics.Assassin);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            player.Effects.IsDefending = true;
            assassin.SpecialAttacks[0].Attack(player);

            Assert.That(player.Health, Is.LessThan(player.MaxHealth));
            GameStatistics.ResetGameStatistics();
        }
    }
}
