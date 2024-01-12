using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics;
using Console_Crawler.GameVariables.Statistics.PlayerStatistics;
using NUnit.Framework;

namespace Console_Crawler.GameCharacters.HostileMobs.__tests__
{
    [TestFixture]
    internal class StoneGolem_Test
    {
        [Test]
        public void StoneGolem_Constructor_Test()
        {
            StoneGolem stoneGolem = new StoneGolem("Stone Golem", AllEnemyStatistics.StoneGolem);

            Assert.That(stoneGolem.Name, Is.EqualTo("Stone Golem"));
            Assert.That(stoneGolem.Attack, Is.EqualTo(AllEnemyStatistics.StoneGolem.BaseAttack));
            Assert.That(stoneGolem.Armor, Is.EqualTo(AllEnemyStatistics.StoneGolem.BaseArmor));
            Assert.That(stoneGolem.Strength, Is.EqualTo(AllEnemyStatistics.StoneGolem.Strength));
            Assert.That(stoneGolem.Health, Is.EqualTo(AllEnemyStatistics.StoneGolem.BaseHealth));
            Assert.That(stoneGolem.Effects.IsDefending, Is.EqualTo(false));
            Assert.That(stoneGolem.Effects.IsStunned, Is.EqualTo(false));
            Assert.That(stoneGolem.Effects.IsPoisoned, Is.EqualTo(false));
            Assert.That(stoneGolem.Effects.IsBurning, Is.EqualTo(false));
            Assert.That(stoneGolem.SpecialAttacks[0].Name, Is.EqualTo("Slam"));
        }

        [Test]
        public void StoneGolem_SlamAttack_Test()
        {
            StoneGolem stoneGolem = new StoneGolem("Stone Golem", AllEnemyStatistics.StoneGolem);
            Player player = new Player("Player", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            stoneGolem.SpecialAttacks[0].Attack(player);

            Assert.That(player.Health, Is.LessThan(player.MaxHealth));
            GameStatistics.ResetGameStatistics();
        }

        [Test]
        public void StoneGolem_SlamAttack_Stun_Test()
        {
            StoneGolem stoneGolem = new StoneGolem("Stone Golem", AllEnemyStatistics.StoneGolem);
            Player player = new Player("Player", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            while (!player.Effects.IsStunned)
            {
                stoneGolem.SpecialAttacks[0].Attack(player);
            }

            Assert.That(player.Effects.IsStunned, Is.EqualTo(true));
            GameStatistics.ResetGameStatistics();
        }
    }
}
