using Console_Crawler.GameCharacters.HostileMobs.MiniBosses;
using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics;
using Console_Crawler.GameVariables.Statistics.PlayerStatistics;
using NUnit.Framework;

namespace Console_Crawler.GameCharacters.HostileMobs.__tests__
{
    [TestFixture]
    internal class DemonicSorcerer_Test
    {
        [Test]
        public void Sorcerer_Constructor_Test()
        {
            DemonicSorcerer sorcerer = new DemonicSorcerer("Demonic Sorcerer", AllEnemyStatistics.DemonicSorcerer);

            Assert.That(sorcerer.Name, Is.EqualTo("Demonic Sorcerer"));
            Assert.That(sorcerer.Attack, Is.EqualTo(AllEnemyStatistics.DemonicSorcerer.BaseAttack));
            Assert.That(sorcerer.Armor, Is.EqualTo(AllEnemyStatistics.DemonicSorcerer.BaseArmor));
            Assert.That(sorcerer.Strength, Is.EqualTo(AllEnemyStatistics.DemonicSorcerer.Strength));
            Assert.That(sorcerer.Health, Is.EqualTo(AllEnemyStatistics.DemonicSorcerer.BaseHealth));
            Assert.That(sorcerer.EXP, Is.EqualTo(AllEnemyStatistics.DemonicSorcerer.BaseEXP));
            Assert.That(sorcerer.Gold, Is.EqualTo(AllEnemyStatistics.DemonicSorcerer.Gold));
            Assert.That(sorcerer.SpecialAttacks[0].Name, Is.EqualTo("Hellfire Blast"));
            Assert.That(sorcerer.SpecialAttacks[1].Name, Is.EqualTo("Soulsteal"));
            Assert.That(sorcerer.SpecialAttacks[2].Name, Is.EqualTo("Dark Pact"));
            Assert.That(sorcerer.HellFireBlastDamage, Is.EqualTo(AllEnemyStatistics.DemonicSorcerer.BaseHellFireBlastDamage));
            Assert.That(sorcerer.BurnDamage, Is.EqualTo(AllEnemyStatistics.DemonicSorcerer.BurnDamage));
            Assert.That(sorcerer.Effects.IsStunned, Is.EqualTo(false));
            Assert.That(sorcerer.Effects.IsBurning, Is.EqualTo(false));
            Assert.That(sorcerer.Effects.IsDefending, Is.EqualTo(false));
            Assert.That(sorcerer.Effects.IsPoisoned, Is.EqualTo(false));
        }

        [Test]
        public void Sorcerer_HellFireBlastAttack_Test()
        { 
            DemonicSorcerer sorcerer = new DemonicSorcerer("Demonic Sorcerer", AllEnemyStatistics.DemonicSorcerer);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            sorcerer.SpecialAttacks[0].Attack(player);

            Assert.That(player.Health, Is.LessThan(player.MaxHealth));
            GameStatistics.ResetGameStatistics();
        }

        [Test]
        public void Sorcerer_HellFireBlastAttack_Burn_Test()
        {
            DemonicSorcerer sorcerer = new DemonicSorcerer("Demonic Sorcerer", AllEnemyStatistics.DemonicSorcerer);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            while (!player.Effects.IsBurning)
            {
                sorcerer.SpecialAttacks[0].Attack(player);
            }

            Assert.That(player.Effects.IsBurning, Is.EqualTo(true));
            Assert.That(player.EffectTurns.BurnTurns, Is.EqualTo(3));
            GameStatistics.ResetGameStatistics();
        }

        [Test]
        public void Sorcerer_SoulstealAttack_Test()
        {
            DemonicSorcerer sorcerer = new DemonicSorcerer("Demonic Sorcerer", AllEnemyStatistics.DemonicSorcerer);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            sorcerer.SpecialAttacks[1].Attack(player);

            Assert.That(player.Health, Is.LessThan(player.MaxHealth));
            Assert.That(sorcerer.Health, Is.GreaterThan(AllEnemyStatistics.DemonicSorcerer.BaseHealth));
            GameStatistics.ResetGameStatistics();
        }

        [Test]
        public void Sorcerer_DarkPactAttack_Test()
        {
            DemonicSorcerer sorcerer = new DemonicSorcerer("Demonic Sorcerer", AllEnemyStatistics.DemonicSorcerer);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            sorcerer.SpecialAttacks[2].Attack(player);

            Assert.That(sorcerer.Health, Is.LessThan(AllEnemyStatistics.DemonicSorcerer.BaseHealth));
            Assert.That(sorcerer.Attack, Is.GreaterThan(AllEnemyStatistics.DemonicSorcerer.BaseAttack));
            GameStatistics.ResetGameStatistics();
        }
    }
}
