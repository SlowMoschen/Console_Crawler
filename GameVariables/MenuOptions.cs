namespace Console_Crawler.GameVariables
{
    internal class MenuOptions
    {
        public static string[] StarterWeapons { get; } = { "Sword", "Axe", "Mace" };
        public static string[] DifficultyOptions { get; } = { "Easy", "Normal", "Hard", "Boss", "Dev" };
        public static string[] BattleOptions { get; } = { "Attack", "Rest", "Use Item", "Defend", "Run Away" };
        public static string[]? AttackOptions { get; set; }
        public static string[] MainMenuOptions { get; } = { "Enter Dungeon", "Shop", "Inventory", "Stats", "Game Infos" };
        public static string[] ShopMenuOptions { get; } = { "Buy", "Exit Shop" };
        public static string[] ShopItems { get; } = { "Heal Potion", "Strength Potion", "Endurance Potion", "Exit" };
        public static string[] InventoryMenuOptions { get; } = { "Use Item", "Exit Inventory" };
    }
}
