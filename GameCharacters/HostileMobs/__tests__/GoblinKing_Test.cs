using Console_Crawler.GameCharacters.HostileMobs.MiniBosses;
using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics;
using Console_Crawler.GameVariables.Statistics.PlayerStatistics;
using Console_Crawler.Items.Potions;
using NUnit.Framework;

namespace Console_Crawler.GameCharacters.HostileMobs.__tests__
{
    [TestFixture]
    internal class GoblinKing_Test
    {
        [Test]
        public void GoblinKing_Constructor_Test()
        { 
            GoblinKing goblinKing = new GoblinKing("Goblin King", AllEnemyStatistics.GoblinKing);

            Assert.That(goblinKing.Name, Is.EqualTo("Goblin King"));
            Assert.That(goblinKing.EnemyStats, Is.EqualTo(AllEnemyStatistics.GoblinKing));
            Assert.That(goblinKing.StealAmount, Is.EqualTo(AllEnemyStatistics.GoblinKing.StealAmount));
            Assert.That(goblinKing.Attack, Is.EqualTo(AllEnemyStatistics.GoblinKing.BaseAttack));
            Assert.That(goblinKing.Armor, Is.EqualTo(AllEnemyStatistics.GoblinKing.BaseArmor));
            Assert.That(goblinKing.Strength, Is.EqualTo(AllEnemyStatistics.GoblinKing.Strength));
            Assert.That(goblinKing.Health, Is.EqualTo(AllEnemyStatistics.GoblinKing.BaseHealth));
            Assert.That(goblinKing.EXP, Is.EqualTo(AllEnemyStatistics.GoblinKing.BaseEXP));
            Assert.That(goblinKing.Gold, Is.EqualTo(AllEnemyStatistics.GoblinKing.Gold));
            Assert.That(goblinKing.SpecialAttacks[0].Name, Is.EqualTo("Enrage"));
            Assert.That(goblinKing.SpecialAttacks[1].Name, Is.EqualTo("Treasure Drain"));
            Assert.That(goblinKing.SpecialAttacks[2].Name, Is.EqualTo("Golden Barrage"));
        }

        [Test]
        public void GoblinKing_Enrage_NotBuffed_Test()
        {
            GoblinKing goblinKing = new GoblinKing("Goblin King", AllEnemyStatistics.GoblinKing);

            goblinKing.SpecialAttacks[0].Attack(null);

            Assert.That(goblinKing.Attack, Is.EqualTo(AllEnemyStatistics.GoblinKing.BaseAttack + AllEnemyStatistics.GoblinKing.EnrageExtraAttack));
            Assert.That(goblinKing.Armor, Is.EqualTo(AllEnemyStatistics.GoblinKing.BaseArmor + AllEnemyStatistics.GoblinKing.EnrageExtraArmor));
            Assert.That(goblinKing.EffectTurns.BuffedTurns, Is.EqualTo(AllEnemyStatistics.GoblinKing.EnragedTurns));
            GameStatistics.ResetGameStatistics();
        }

        [Test]
        public void GoblinKing_Enrage_AlreadyBuffed_Test()
        {
            GoblinKing goblinKing = new GoblinKing("Goblin King", AllEnemyStatistics.GoblinKing);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            goblinKing.IsEnraged = true;
            goblinKing.EffectTurns.BuffedTurns = 1;

            goblinKing.SpecialAttacks[0].Attack(player);

            Assert.That(goblinKing.EffectTurns.BuffedTurns, Is.EqualTo(1).And.Not.EqualTo(3));
            GameStatistics.ResetGameStatistics();
        }

        [Test]
        public void GoblinKing_TreasureDrain_Test()
        {
            GoblinKing goblinKing = new GoblinKing("Goblin King", AllEnemyStatistics.GoblinKing);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            player.Inventory.AddGold(100);
            player.Inventory.AddItem(new HealthPotion());

            goblinKing.EnemyStats.ItemStealChance = 100;

            goblinKing.SpecialAttacks[1].Attack(player);

            Assert.That(goblinKing.Gold, Is.EqualTo(AllEnemyStatistics.GoblinKing.Gold + AllEnemyStatistics.GoblinKing.StealAmount));
            Assert.That(player.Inventory.Gold, Is.EqualTo(100 - AllEnemyStatistics.GoblinKing.StealAmount));
            Assert.That(player.Inventory.Items.Count, Is.EqualTo(0));
            Assert.That(player.Health, Is.LessThan(player.MaxHealth));
            GameStatistics.ResetGameStatistics();
        }

        [Test]
        public void GoblinKing_GoldBarrage_Test()
        {
            GoblinKing goblinKing = new GoblinKing("Goblin King", AllEnemyStatistics.GoblinKing);
            Player player = new Player("TestPlayer", PlayerStats.InitialAttack, PlayerStats.InitialArmor, PlayerStats.InitialStrength, PlayerStats.InitialHealth);

            goblinKing.SpecialAttacks[2].Attack(player);

            Assert.That(goblinKing.Gold, Is.EqualTo(goblinKing.EnemyStats.Gold - (goblinKing.EnemyStats.Gold / goblinKing.EnemyStats.BarrageGoldDecrease)));
            Assert.That(player.Health, Is.LessThan(player.MaxHealth));
            GameStatistics.ResetGameStatistics();
        }
    }
}
