using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Crawler.GameUtilities;

namespace Console_Crawler.GameCharacters
{
    internal class GameCharacterBuilder(string name, int attack, int armor, double strength, int health)
    {
        public string Name { get; set; } = name;
        public int Attack { get; set; } = attack;
        public int Armor { get; set; } = armor;
        public double Strength { get; set; } = strength;
        public int Health { get; set; } = health;
        public class EffectsBools
        {
            public bool IsDefending { get; set; } = false;
            public bool IsStunned { get; set; } = false;
            public bool IsPoisoned { get; set; } = false;
            public bool IsBurning { get; set; } = false;
        }
        public class AllEffectTurns
        {
            public int PoisonTurns { get; set; } = 0;
            public int BurnTurns { get; set; } = 0;
            public int strenghtBuffTurns { get; set; } = 0;
        }
        public EffectsBools Effects { get; set; } = new EffectsBools();
        public AllEffectTurns EffectTurns { get; set; } = new AllEffectTurns();

        public virtual void NormalAttack(GameCharacterBuilder target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength);

            if(target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                return;
            }
            else 
            { 
                target.Health -= damage;
            }
        }

        public void Defend()
        {
            this.Effects.IsDefending = true;
        }

       /* public void ApplyOverTimeEffects(GameCharacterBuilder enemy)
        {
            this.ApplyPoisonDamage(enemy);
            this.ApplyBurnDamage(enemy);
        }

        public void ApplyPoisonDamage(GameCharacterBuilder enemy)
        {
            if (this.EffectTurns.PoisonTurns > 0)
            {

                if (enemy is GiantSpider)
                {
                    this.Health -= GameSettings.General.PoisonDamage * GameSettings.General.GiantSpiderPoisonMultiplier;
                }
                else
                {
                    this.Health -= GameSettings.General.PoisonDamage;
                }
                this.EffectTurns.PoisonTurns--;
            }
            else
            {
                this.Effects.IsPoisoned = false;
            }
        }

        public void ApplyBurnDamage(GameCharacterBuilder enemy)
        {
            if (this.EffectTurns.BurnTurns > 0)
            {
                if (enemy is Dragon)
                {
                    this.Health -= GameSettings.General.BurnDamage * GameSettings.General.DragonBurnMultiplier;
                }
                else
                {
                    this.Health -= GameSettings.General.BurnDamage;
                }
                this.EffectTurns.BurnTurns--;
            }
            else
            {
                this.Effects.IsBurning = false;
            }
        }*/

        public virtual void PrintBattleStats()
        {
            Console.WriteLine($" Name: {this.Name}");
            Console.WriteLine($" Health: {this.Health}");
            Console.WriteLine($" Armor: {this.Armor}");
        }

        public void PrintStats()
        {
            Console.WriteLine($" Name: {this.Name}");
            Console.WriteLine($" Attack: {this.Attack}");
            Console.WriteLine($" Armor: {this.Armor}");
            Console.WriteLine($" Strength: {this.Strength}");
            Console.WriteLine($" Health: {this.Health}");
        }
    }
}
