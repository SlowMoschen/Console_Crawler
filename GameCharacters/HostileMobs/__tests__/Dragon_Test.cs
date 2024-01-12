using Console_Crawler.GameCharacters.HostileMobs.Bosses;
using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics;
using Console_Crawler.GameVariables.Statistics.PlayerStatistics;
using NUnit.Framework;

namespace Console_Crawler.GameCharacters.HostileMobs.__tests__
{
    [TestFixture]
    internal class Dragon_Test
    {
        [Test]
        public void Dragon_Constructor_Test()
        {
            Dragon dragon = new Dragon("Dragon", AllEnemyStatistics.Dragon);

            Assert.That(dragon.Name, Is.EqualTo("Dragon"));
            Assert.That(dragon.Attack, Is.EqualTo(AllEnemyStatistics.Dragon.BaseAttack));
            Assert.That(dragon.Armor, Is.EqualTo(AllEnemyStatistics.Dragon.BaseArmor));
            Assert.That(dragon.Strength, Is.EqualTo(AllEnemyStatistics.Dragon.Strength));
            Assert.That(dragon.Health, Is.EqualTo(AllEnemyStatistics.Dragon.BaseHealth));
            Assert.That(dragon.EXP, Is.EqualTo(AllEnemyStatistics.Dragon.BaseEXP));
            Assert.That(dragon.Gold, Is.EqualTo(AllEnemyStatistics.Dragon.Gold));
            Assert.That(dragon.SpecialAttacks[0].Name, Is.EqualTo("Fire Breath"));
            Assert.That(dragon.SpecialAttacks[1].Name, Is.EqualTo("Rock Throw"));
            Assert.That(dragon.SpecialAttacks[2].Name, Is.EqualTo("Tailstrike"));
            Assert.That(dragon.FireBreathDamage, Is.EqualTo(AllEnemyStatistics.Dragon.FireBreathDamage));
            Assert.That(dragon.RockThrowDamage, Is.EqualTo(AllEnemyStatistics.Dragon.RockThrowDamage));
            Assert.That(dragon.TailStrikeDamage, Is.EqualTo(AllEnemyStatistics.Dragon.TailStrikeDamage));
            Assert.That(dragon.BurnDamage, Is.EqualTo(AllEnemyStatistics.Dragon.BurnDamage));
            Assert.That(dragon.Effects.IsStunned, Is.EqualTo(false));
            Assert.That(dragon.Effects.IsBurning, Is.EqualTo(false));
            Assert.That(dragon.Effects.IsDefending, Is.EqualTo(false));
            Assert.That(dragon.Effects.IsPoisoned, Is.EqualTo(false));
        }

        [Test]
        public void Dragon_FireBreathAttack_Test()
        {
            Dragon dragon = new Dragon("Dragon", AllEnemyStatistics.Dragon);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            dragon.SpecialAttacks[0].Attack(player);

            Assert.That(player.Health, Is.LessThan(player.MaxHealth));
            GameStatistics.ResetGameStatistics();
        }

        [Test]
        public void Dragon_FireBreathAttack_Burn_Test()
        {
            Dragon dragon = new Dragon("Dragon", AllEnemyStatistics.Dragon);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            while (!player.Effects.IsBurning)
            {
                dragon.SpecialAttacks[0].Attack(player);
            }

            Assert.That(player.Effects.IsBurning, Is.EqualTo(true));
            Assert.That(player.EffectTurns.BurnTurns, Is.EqualTo(3));
            GameStatistics.ResetGameStatistics();
        }

        [Test]
        public void Dragon_RockThrowAttack_Test()
        {
            Dragon dragon = new Dragon("Dragon", AllEnemyStatistics.Dragon);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            dragon.SpecialAttacks[1].Attack(player);

            Assert.That(player.Health, Is.LessThan(player.MaxHealth));
            GameStatistics.ResetGameStatistics();
        }

        [Test]
        public void Dragon_RockThrowAttack_Stun_Test()
        {
            Dragon dragon = new Dragon("Dragon", AllEnemyStatistics.Dragon);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            while (!player.Effects.IsStunned)
            {
                dragon.SpecialAttacks[1].Attack(player);
            }

            Assert.That(player.Effects.IsStunned, Is.EqualTo(true));
            GameStatistics.ResetGameStatistics();
        }

        [Test]
        public void Dragon_TailStrikeAttack_WithoutDefend_Test()
        {
            Dragon dragon = new Dragon("Dragon", AllEnemyStatistics.Dragon);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            dragon.SpecialAttacks[2].Attack(player);

            Assert.That(player.Health, Is.LessThan(player.MaxHealth));
            GameStatistics.ResetGameStatistics();
        }

        [Test]
        public void Dragon_TailStrikeAttack_WithDefend_Test()
        {
            Dragon dragon = new Dragon("Dragon", AllEnemyStatistics.Dragon);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            player.Effects.IsDefending = true;
            dragon.SpecialAttacks[2].Attack(player);

            Assert.That(player.Health, Is.LessThan(player.MaxHealth));
            Assert.That(player.Effects.IsDefending, Is.EqualTo(false));
            GameStatistics.ResetGameStatistics();
        }
    }
}
