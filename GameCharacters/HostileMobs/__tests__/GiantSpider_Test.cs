using Console_Crawler.GameCharacters.HostileMobs.MiniBosses;
using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics;
using Console_Crawler.GameVariables.Statistics.PlayerStatistics;
using NUnit.Framework;

namespace Console_Crawler.GameCharacters.HostileMobs.__tests__
{
    [TestFixture]
    internal class GiantSpider_Test
    {
        [Test]
        public void GiantSpider_Constructor_Test()
        {
            GiantSpider giantSpider = new GiantSpider("Giant Spider", AllEnemyStatistics.GiantSpider);

            Assert.That(giantSpider.Name, Is.EqualTo("Giant Spider"));
            Assert.That(giantSpider.Attack, Is.EqualTo(AllEnemyStatistics.GiantSpider.BaseAttack));
            Assert.That(giantSpider.Armor, Is.EqualTo(AllEnemyStatistics.GiantSpider.BaseArmor));
            Assert.That(giantSpider.Strength, Is.EqualTo(AllEnemyStatistics.GiantSpider.Strength));
            Assert.That(giantSpider.Health, Is.EqualTo(AllEnemyStatistics.GiantSpider.BaseHealth));
            Assert.That(giantSpider.EXP, Is.EqualTo(AllEnemyStatistics.GiantSpider.BaseEXP));
            Assert.That(giantSpider.Gold, Is.EqualTo(AllEnemyStatistics.GiantSpider.Gold));
            Assert.That(giantSpider.PoisonDamage, Is.EqualTo(AllEnemyStatistics.GiantSpider.BasePoisonDamage));
            Assert.That(giantSpider.Effects.IsPoisoned, Is.EqualTo(false));
            Assert.That(giantSpider.Effects.IsStunned, Is.EqualTo(false));
            Assert.That(giantSpider.Effects.IsDefending, Is.EqualTo(false));
            Assert.That(giantSpider.Effects.IsBurning, Is.EqualTo(false));
            Assert.That(giantSpider.SpecialAttacks[0].Name, Is.EqualTo("Poison Bite"));
            Assert.That(giantSpider.SpecialAttacks[1].Name, Is.EqualTo("Webshot"));
        }

        [Test]
        public void GiantSpider_PoisonBiteAttack_Test()
        {
            GiantSpider giantSpider = new GiantSpider("Giant Spider", AllEnemyStatistics.GiantSpider);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            giantSpider.SpecialAttacks[0].Attack(player);

            Assert.That(player.Health, Is.LessThan(player.MaxHealth));
            GameStatistics.ResetGameStatistics();
        }

        [Test]
        public void GiantSpider_WebShotAttack_Test()
        {
            GiantSpider giantSpider = new GiantSpider("Giant Spider", AllEnemyStatistics.GiantSpider);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            giantSpider.SpecialAttacks[1].Attack(player);

            Assert.That(player.Health, Is.LessThan(player.MaxHealth));
            GameStatistics.ResetGameStatistics();
        }

        [Test]
        public void GiantSpider_PoisonBiteAttack_Poison_Test()
        {
            GiantSpider giantSpider = new GiantSpider("Giant Spider", AllEnemyStatistics.GiantSpider);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            while (!player.Effects.IsPoisoned)
            {
                giantSpider.SpecialAttacks[0].Attack(player);
            }

            Assert.That(player.Effects.IsPoisoned, Is.EqualTo(true));
            Assert.That(player.EffectTurns.PoisonTurns, Is.EqualTo(3));
            GameStatistics.ResetGameStatistics();
        }

        [Test]
        public void GiantSpider_WebShotAttack_Stun_Test()
        {
            GiantSpider giantSpider = new GiantSpider("Giant Spider", AllEnemyStatistics.GiantSpider);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            while (!player.Effects.IsStunned)
            {
                giantSpider.SpecialAttacks[1].Attack(player);
            }

            Assert.That(player.Effects.IsStunned, Is.EqualTo(true));
            GameStatistics.ResetGameStatistics();
        }
    }
}
