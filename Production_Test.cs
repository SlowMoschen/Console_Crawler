using Console_Crawler.GameVariables;
using Console_Crawler.GameVariables.Statistics;
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

            FieldInfo[] gameStatsFields = GameStatsType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach(FieldInfo field in gameStatsFields)
            {
                Assert.That(field.GetValue(null), Is.EqualTo(0));
            }

            // Get all fields from GameBools and check if they are all false
            Type GameBoolsType = typeof(GameBools);

            FieldInfo[] gameBoolsFields = GameBoolsType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach(FieldInfo field in gameBoolsFields)
            {
                Assert.That(field.GetValue(null), Is.EqualTo(false));
            }
        }
    }
}
