using Console_Crawler.GameVariables;
using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.GameVariables.Statistics.PlayerStatistics;
using NUnit.Framework;
using System.Reflection;

namespace Console_Crawler
{
    [TestFixture]
    internal class Production_Test
    {
        [Test]
        public void Ready_For_Production_Test()
        {

            // Get all fields from GameStatistics and check if they are all 0
            Type GameStatsType = typeof(GameStatistics);

            FieldInfo[] gameStatsFields = GameStatsType.GetFields(BindingFlags.NonPublic | BindingFlags.Static);

            foreach(FieldInfo field in gameStatsFields)
            {
                // Skip the Version field - is string and not important for this test
                if(field.FieldType == typeof(int))
                {
                    Assert.That(field.GetValue(null), Is.EqualTo(0));
                    Console.WriteLine(field.Name);
                }
            }

            // Get all fields from GameBools and check if they are all false
            Type GameBoolsType = typeof(GameBools);

            FieldInfo[] gameBoolsFields = GameBoolsType.GetFields(BindingFlags.NonPublic | BindingFlags.Static);

            foreach(FieldInfo field in gameBoolsFields)
            {
                Assert.That(field.GetValue(null), Is.EqualTo(false));
            }

            // check if Playerstats are correct with these values
            Assert.That(PlayerStats.InitialAttack, Is.EqualTo(10));
            Assert.That(PlayerStats.InitialStrength, Is.EqualTo(1.0));
            Assert.That(PlayerStats.InitialArmor, Is.EqualTo(10));
            Assert.That(PlayerStats.InitialHealth, Is.EqualTo(100));
            Assert.That(PlayerStats.InitialMaxHealth, Is.EqualTo(100));
            Assert.That(PlayerStats.EXP, Is.EqualTo(0));
            Assert.That(PlayerStats.EXPToNextLevel, Is.EqualTo(100));
            Assert.That(PlayerStats.Level, Is.EqualTo(1));
            Assert.That(PlayerStats.MaxLevel, Is.EqualTo(30));
        }
    }
}
