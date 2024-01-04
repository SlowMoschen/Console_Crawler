using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Crawler.GameCharacters
{
    public enum EnemyAction
    {
        NormalAttack,
        SpecialAttack,
        Defend
    }

    internal class Enemy : GameCharacterBuilder
    {
        private static Random random = new Random();
        public int EXP { get; set; } = 0;
        public int Gold { get; set; } = 0;
        public List<(string Name, Action<Player> Attack)> ?SpecialAttacks { get; set; }

        public Enemy(string name, int attack, int armor, double strength, int health, int EXP, int Gold) : base(name, attack, armor, strength, health)
        {
            this.EXP = EXP;
            this.Gold = Gold;
        }

        public EnemyAction GetRandomAction()
        {
            int choice = random.Next(1, 4);

            if(choice == 2 && SpecialAttacks?.Count > 0)
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
            string move = "";

            switch(action)
            {
                case EnemyAction.NormalAttack:
                    this.NormalAttack(target);
                    move = "Normal Attack";
                    break;
                case EnemyAction.SpecialAttack:
                    move = ExecuteSpecialAttack(target);
                    break;
                case EnemyAction.Defend:
                    this.Defend();
                    move = "Defend";
                    break;
                default:
                    move = "Nothing Happend";
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
