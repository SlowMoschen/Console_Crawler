using Console_Crawler.GameVariables.Statistics.EnemyStatistics;
using Console_Crawler.GameVariables.Statistics.PlayerStatistics;
using NUnit.Framework;


namespace Console_Crawler.GameCharacters.HostileMobs.__tests__
{
    [TestFixture]
    internal class Spider_Test
    {
        [Test]
        public void Spider_Constructor_Test()
        {
            Assert.That(AllEnemyStatistics.Spider, Is.Not.Null, "Stats are null");
            Spider spider = new Spider("Spider", AllEnemyStatistics.Spider);

            Assert.That(spider.Name, Is.EqualTo("Spider"));
            Assert.That(spider.Attack, Is.EqualTo(AllEnemyStatistics.Spider.BaseAttack));
            Assert.That(spider.Armor, Is.EqualTo(AllEnemyStatistics.Spider.BaseArmor));
            Assert.That(spider.Strength, Is.EqualTo(AllEnemyStatistics.Spider.Strength));
            Assert.That(spider.Health, Is.EqualTo(AllEnemyStatistics.Spider.BaseHealth));
            Assert.That(spider.EXP, Is.EqualTo(AllEnemyStatistics.Spider.BaseEXP));
            Assert.That(spider.Gold, Is.EqualTo(AllEnemyStatistics.Spider.Gold));
            Assert.That(spider.PoisonDamage, Is.EqualTo(AllEnemyStatistics.Spider.BasePoisonDamage));
            Assert.That(spider.Effects.IsDefending, Is.False);
            Assert.That(spider.Effects.IsStunned, Is.False);
            Assert.That(spider.Effects.IsPoisoned, Is.False);
            Assert.That(spider.Effects.IsBurning, Is.False);
            Assert.That(spider.SpecialAttacks[0].Name, Is.EqualTo("Spit"));
        }

        [Test]
        public void Spider_SpitAttack_Test()
        {
            Spider spider = new Spider("Spider", AllEnemyStatistics.Spider);
            Player player = new Player("Player", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            spider.SpecialAttacks[0].Attack(player);

            Assert.That(player.Health, Is.LessThan(player.MaxHealth));
        }

        [Test]
        public void Spider_SpitAttack_Poison_Test()
        {
            Spider spider = new Spider("Spider", AllEnemyStatistics.Spider);
            Player player = new Player("Player", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            while(!player.Effects.IsPoisoned)
            {
                spider.SpecialAttacks[0].Attack(player);
            }

            Assert.That(player.Effects.IsPoisoned, Is.True);
        }
    }
}
