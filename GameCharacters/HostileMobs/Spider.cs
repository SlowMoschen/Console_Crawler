//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Console_Crawler.GameUtilities;

//namespace Console_Crawler.GameCharacters.HostileMobs
//{
//    internal class Spider : Enemy
//    {
//        public Spider(string name, int attack, int armor, double strength, int health, int EXP, int Gold) : base(name, attack, armor, strength, health, EXP, Gold)
//        {
//            this.SpecialAttacks = new List<(string Name, Action<Player> Attack)>
//            {
//                ("Spit", SpitAttack)
//            };
//        }

//        public void SpitAttack(Player target)
//        {
//            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength);

//            if(target.Effects.IsDefending)
//            {
//                target.Effects.IsDefending = false;
//                return;
//            }
//            else
//            {
//                target.Health -= damage;
//                if(Randomizer.GetChance()
//            }
//        }
//    }
//}
