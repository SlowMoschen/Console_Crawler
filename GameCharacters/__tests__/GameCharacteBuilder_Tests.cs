using Console_Crawler.GameCharacters.HostileMobs;
using Console_Crawler.GameCharacters.HostileMobs.MiniBosses;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics;
using NUnit.Framework;

namespace Console_Crawler.GameCharacters.__tests__
{
    [TestFixture]
    internal class GameCharacteBuilder_Tests
    {
        [Test]
        public void GameCharacterBuilder_Constructor_Test()
        {
            GameCharacter gameCharacter = new GameCharacter("Test", 10, 10, 10, 10);

            Assert.That(gameCharacter.Name, Is.EqualTo("Test"));
            Assert.That(gameCharacter.Attack, Is.EqualTo(10));
            Assert.That(gameCharacter.Armor, Is.EqualTo(10));
            Assert.That(gameCharacter.Strength, Is.EqualTo(10));
            Assert.That(gameCharacter.Health, Is.EqualTo(10));
        }

        [Test]
        public void GameCharacterBuilder_NormalAttack_WithOutDefend_Test()
        {
            GameCharacter gameCharacter = new GameCharacter("Test", 10, 10, 10, 10);
            GameCharacter target = new GameCharacter("Test", 10, 10, 10, 10);

            gameCharacter.NormalAttack(target);

            Assert.That(target.Health, Is.LessThanOrEqualTo(0));
        }

        [Test]
        public void GameCharacterBuilder_NormalAttack_WithDefend_Test()
        {
            GameCharacter gameCharacter = new GameCharacter("Test", 10, 10, 10, 10);
            GameCharacter target = new GameCharacter("Test", 10, 10, 10, 10);

            target.Effects.IsDefending = true;
            gameCharacter.NormalAttack(target);

            Assert.That(target.Health, Is.EqualTo(10));
        }

        [Test]
        public void GameCharacterBuilder_Defend_Test()
        {
            GameCharacter gameCharacter = new GameCharacter("Test", 10, 10, 10, 10);

            gameCharacter.Defend();

            Assert.That(gameCharacter.Effects.IsDefending, Is.EqualTo(true));
        }

        [Test]
        public void GameCharacterBuilder_ApplyPoisonDamage_Test()
        {
            GameCharacter gameCharacter = new GameCharacter("Test", 10, 10, 10, 10);
            Spider target = new Spider("Spider", AllEnemyStatistics.Spider);

            gameCharacter.Effects.IsPoisoned = true;
            gameCharacter.EffectTurns.PoisonTurns = 1;
            gameCharacter.ApplyPoisonDamage(target);

            Assert.That(gameCharacter.Health, Is.EqualTo(5));
            Assert.That(gameCharacter.EffectTurns.PoisonTurns, Is.EqualTo(0));
        }

        [Test]
        public void GameCharacterBuilder_ApplyBurnDamage_Test()
        {
            GameCharacter gameCharacter = new GameCharacter("Test", 10, 10, 10, 10);
            DemonicSorcerer target = new DemonicSorcerer("Spider", AllEnemyStatistics.DemonicSorcerer);

            gameCharacter.Effects.IsBurning = true;
            gameCharacter.EffectTurns.BurnTurns = 1;
            gameCharacter.ApplyBurnDamage(target);

            Assert.That(gameCharacter.Health, Is.EqualTo(0));
            Assert.That(gameCharacter.EffectTurns.BurnTurns, Is.EqualTo(0));
        }

        [Test]
        public void GameCharacter_IsStunned_Test()
        {
            GameCharacter gameCharacter = new GameCharacter("Test", 10, 10, 10, 10);

            gameCharacter.Effects.IsStunned = true;

            Assert.That(gameCharacter.Effects.IsStunned, Is.EqualTo(true));
        }

    }
}
