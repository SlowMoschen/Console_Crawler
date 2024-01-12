using Console_Crawler.GameCharacters;
using NUnit.Framework;

namespace Console_Crawler.GameUtilities.__tests__
{
    [TestFixture]
    internal class SaveGameManager_Test
    {
        private static string executablePath = AppDomain.CurrentDomain.BaseDirectory;
        private static string saveGamePath = Path.Combine(executablePath, "SaveGame.json");

        [Test]
        public void SaveGameToFile_Test()
        {
            // Arrange
            Player player = new Player("TestPlayer", 1,1,1,10);

            // Act
            bool result = SaveGameManager.SaveGameToFile(player);

            // Assert
            Assert.That(result, Is.True);
            SaveGameManager.DeleteSaveGame();
            Assert.That(File.Exists(saveGamePath), Is.False);
        }

        [Test]
        public void LoadGameFromFile_Test()
        {
            // Arrange
            Player player = new Player("TestPlayer", 1, 1, 1, 10);
            SaveGameManager.SaveGameToFile(player);

            // Act
            SaveGame saveGame = SaveGameManager.LoadGameFromFile();

            // Assert
            Assert.That(saveGame.Player.Name, Is.EqualTo("TestPlayer"));
            SaveGameManager.DeleteSaveGame();
            Assert.That(File.Exists(saveGamePath), Is.False);
        }
    }
}
