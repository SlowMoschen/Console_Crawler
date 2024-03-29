﻿using Console_Crawler.GameVariables.Statistics.PlayerStatistics;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder;
using Console_Crawler.GameCharacters.HostileMobs.Bosses;
using Console_Crawler.GameCharacters.HostileMobs;

// This is the base class for all game Enemies
// Cannot be used directly - must be inherited from - because the stats will be set in the constructor of the inherited class

namespace Console_Crawler.GameCharacters
{
    public enum EnemyAction
    {
        NormalAttack,
        SpecialAttack,
        Defend
    }

    internal class Enemy : GameCharacter
    {
        private static Random random = new Random();
        public int EXP { get; set; } = 0;
        public int Gold { get; set; } = 0;
        public List<(string Name, Action<Player> Attack)> ?SpecialAttacks { get; set; }
        public EnemyStatistics EnemyStats { get; set; }
        public Enemy(string name, EnemyStatistics enemyStatistics) : base(name, 0, 0, 0, 0)
        {
            this.EnemyStats = enemyStatistics;
        }

        public virtual void SetStats()
        {
            this.Attack = CalculateStat(this.EnemyStats.BaseAttack, GameVariables.GameSettings.EnemyScaling.AttackScaling, GameVariables.GameSettings.EnemyScaling.ScalingIntervals.AttackInterval);

            //This is commented out because I want to test the game without armor scaling
            //this.Armor = CalculateStat(this.EnemyStats.BaseArmor, GameVariables.GameSettings.EnemyScaling.AttackScaling, GameVariables.GameSettings.EnemyScaling.ScalingIntervals.ArmorInterval);

            this.Health = CalculateStat(this.EnemyStats.BaseHealth, GameVariables.GameSettings.EnemyScaling.HealthScaling, GameVariables.GameSettings.EnemyScaling.ScalingIntervals.HealthInterval);
            this.EXP = CalculateStat(this.EnemyStats.BaseEXP, GameVariables.GameSettings.EnemyScaling.EXPSScaling, GameVariables.GameSettings.EnemyScaling.ScalingIntervals.EXPInterval);
            this.Armor = this.EnemyStats.BaseArmor;
            this.Strength = this.EnemyStats.Strength;
            this.Gold = this.EnemyStats.Gold;
        }

        public static int CalculateStat(int baseStat, int scaleRating, int levelInterval = 1)
        {
            int level = (PlayerStats.Level - 1) / levelInterval;
            return baseStat + level * scaleRating;
        }

        public override void Defend()
        {
            base.Defend();
            Console.WriteLine($" {this.Name} is defending the next attack!");
        }

        public EnemyAction GetRandomAction()
        {
            int choice = random.Next(0, 3);

            if(choice == 1 && SpecialAttacks?.Count > 0)
            {
                return EnemyAction.SpecialAttack;
            }
            else
            {
                return (EnemyAction)choice;
            }
        }

        public string ExecuteSpecialAttack(Player target)
        {
            if(SpecialAttacks?.Count > 0)
            {
                int index = random.Next(SpecialAttacks.Count);
                var specialAttack = SpecialAttacks[index];
                specialAttack.Attack.Invoke(target);

                return specialAttack.Name;
            }

            return "";
        }

        public string ExecuteAction(Player target, EnemyAction action)
        {
            string move;
            switch (action)
            {
                case EnemyAction.NormalAttack:
                    this.NormalAttack(target);
                    move = "Normal Attack";
                    break;
                case EnemyAction.SpecialAttack:
                    move = ExecuteSpecialAttack(target);
                    break;
                case EnemyAction.Defend:

                    // Stone Golems and Dragons cannot defend
                    if(this is StoneGolem || this is Dragon)
                    {
                        this.NormalAttack(target);
                        move = "Normal Attack";
                        break;
                    }

                    this.Defend();
                    move = "Defend";
                    break;
                default:
                    move = "Nothing Happend";
                    Console.WriteLine(" The Enemy did nothing.");
                    break;
            }
            return move;
        }

        public override void PrintBattleStats()
        {
            Console.WriteLine($" Enemy: {Name}");
            Console.WriteLine($" Health: {Health}");
            Console.WriteLine($" Attack: {Attack}");
            Console.WriteLine($" Armor: {Armor}");
        }
    }
}
