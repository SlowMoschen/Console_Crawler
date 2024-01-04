﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Crawler.GameVariables
{
    internal class MenuOptions
    {
        public static string[] DifficultyOptions { get; } = { "Easy", "Normal", "Hard", "Boss", "Dev" };
        public static string[] BattleOptions { get; } = { "Attack", "Rest", "Use Item", "Defend", "Run Away" };
        public static string[]? AttackOptions { get; set; }
        public static string[] MainMenuOptions { get; } = { "Enter Dungeon", "Shop", "Inventory", "Stats", "Exit Game" };
        public static string[] ShopOptions { get; } = { "Buy", "Exit Shop" };
        public static string[] ShopItems { get; } = { "Heal Potion", "Strength Potion", "Endurance Potion" };
    }
}
