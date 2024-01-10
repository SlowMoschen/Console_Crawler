using Console_Crawler.GameCharacters.HostileMobs;
using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics;
using Console_Crawler.GameVariables.Statistics.PlayerStatistics;
using NUnit.Framework;

namespace Console_Crawler.GameCharacters.__tests__
{
    [TestFixture]
    internal class Enemy_Test
    {
        [Test]
        public void Enemy_Constructor_Test()
        {
            Enemy enemy = new Enemy("Enemy", AllEnemyStatistics.Zombie);

            Assert.That(enemy.Name, Is.EqualTo("Enemy"));
            Assert.That(enemy.EnemyStats.BaseAttack, Is.EqualTo(AllEnemyStatistics.Zombie.BaseAttack));
            Assert.That(enemy.EnemyStats.BaseArmor, Is.EqualTo(AllEnemyStatistics.Zombie.BaseArmor));
            Assert.That(enemy.EnemyStats.BaseHealth, Is.EqualTo(AllEnemyStatistics.Zombie.BaseHealth));
            Assert.That(enemy.EnemyStats.BaseEXP, Is.EqualTo(AllEnemyStatistics.Zombie.BaseEXP));
            Assert.That(enemy.EnemyStats.Gold, Is.EqualTo(AllEnemyStatistics.Zombie.Gold));
            Assert.That(enemy.EnemyStats.Strength, Is.EqualTo(AllEnemyStatistics.Zombie.Strength));

        }

        [Test]
        public void Enemy_CalculateStat_Test()
        {
            int baseStat = 10;
            int scaleRating = 10;
            int levelInterval = 1;

            int result = Enemy.CalculateStat(baseStat, scaleRating, levelInterval);

            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void Enemy_CalculateStat_Test2()
        {
            int baseStat = 20;
            int scaleRating = 15;
            int levelInterval = 1;

            int result = Enemy.CalculateStat(baseStat, scaleRating, levelInterval);

            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void Enemy_SetStats_Test()
        {
            Enemy enemy = new Enemy("Enemy", AllEnemyStatistics.Zombie);

            enemy.SetStats();

            Assert.That(enemy.Attack, Is.EqualTo(AllEnemyStatistics.Zombie.BaseAttack));
            Assert.That(enemy.Armor, Is.EqualTo(AllEnemyStatistics.Zombie.BaseArmor));
            Assert.That(enemy.Strength, Is.EqualTo(AllEnemyStatistics.Zombie.Strength));
            Assert.That(enemy.Health, Is.EqualTo(AllEnemyStatistics.Zombie.BaseHealth));
            Assert.That(enemy.EXP, Is.EqualTo(AllEnemyStatistics.Zombie.BaseEXP));
            Assert.That(enemy.Gold, Is.EqualTo(AllEnemyStatistics.Zombie.Gold));
        }

        [Test]
        public void Enemy_GetRandomAction_Test()
        {
            Enemy enemy = new Enemy("Enemy", AllEnemyStatistics.Zombie);

            EnemyAction result = enemy.GetRandomAction();

            Assert.That(result, Is.Not.EqualTo(null));
        }

        [Test]
        public void Enemy_ExecuteSpecialAttack_Test()
        {
            Zombie enemy = new Zombie("Enemy", AllEnemyStatistics.Zombie);
            Player player = new Player("Player", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            string result = enemy.ExecuteSpecialAttack(player);

            Assert.That(result, Is.Not.EqualTo(null));
            Assert.That(player.Health, Is.Not.EqualTo(player.MaxHealth));
            Assert.That(GameStatistics.TotalDamageDealt, Is.GreaterThan(0));
        }

        [Test]
        public void Enemy_ExecuteAction_Test()
        {
            Enemy enemy = new Zombie("Enemy", AllEnemyStatistics.Zombie);
            Player player = new Player("Player", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            player.Effects.IsDefending = false;
            string result = enemy.ExecuteAction(player, EnemyAction.NormalAttack);

            Assert.That(result, Is.EqualTo("Normal Attack"));
            Assert.That(player.Health, Is.Not.EqualTo(player.MaxHealth));
            Assert.That(GameStatistics.TotalDamageTaken, Is.GreaterThan(0));
        }

        [Test]
        public void Enemy_ExecuteAction_Defend_Test()
        {
            Enemy enemy = new Enemy("Enemy", AllEnemyStatistics.Zombie);
            Player player = new Player("Player", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            string result = enemy.ExecuteAction(player, EnemyAction.Defend);

            Assert.That(result, Is.EqualTo("Defend"));
            Assert.That(enemy.Effects.IsDefending, Is.EqualTo(true));
        }

    }
}
