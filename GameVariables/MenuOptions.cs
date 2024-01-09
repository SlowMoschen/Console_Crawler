using Console_Crawler.GameVariables.Statistics.PlayerStatistics;

namespace Console_Crawler.GameVariables
{
    internal class MenuOptions
    {
        public static string[] StarterWeapons { get; } = { "Sword", "Axe", "Mace" };
        public static string[] DifficultyOptions { get; } = new string[] 
        { 
            "Easy", "Medium", "Hard", "Boss", (GameBools.IsInDevMode ? "Dev" : null) 
        }.Where(option => option != null).ToArray();
        public static string[] BattleOptions { get; } = { "Attack", "Rest", "Use Item", "Defend", "Run Away" };
        public static string[]? AttackOptions { get; set; }
        public static string[] MainMenuOptions { get; } = { "Enter Dungeon", "Shop", "Inventory", "Stats", "Game Infos" };
        public static string[] ShopMenuOptions { get; } = { "Buy", "Exit Shop" };
        public static string[] ShopItems { get; } = { "Heal Potion", "Strength Potion", "Endurance Potion", "Exit" };
        public static string[] InventoryMenuOptions { get; } = { "Use Item", "Exit Inventory" };
        public static string[] StatsMenuOptions { get; } = { $"{PlayerStats.Name} Statistics", "Game Statistics", "Exit Stats" };
        public static string[] GameInfosMenuOptions { get; } = { "Gameplay", "Battle", "Items", "Weapons", "Enemies", "Credits", "All", "Exit Game Infos" };
    }
}
