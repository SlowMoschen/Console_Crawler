
using Console_Crawler.GameCharacters;
using Console_Crawler.GameVariables;

namespace Console_Crawler.GameUtilities.DisplayManager
{
    internal partial class DisplayManager
    {
        public static string DisplayMainMenu(Player player)
        {
            Console.Clear();
            DisplayHeader("Main Menu");
            DisplayLevelProgressBar(player.Level, player.EXP, player.EXPToNextLevel);
            return DisplayOptionsMenu("What would you like to do?", MenuOptions.MainMenuOptions);
        }
    }
}
