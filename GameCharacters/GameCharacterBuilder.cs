using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder;
using Console_Crawler.GameCharacters.HostileMobs;
using Console_Crawler.GameCharacters.HostileMobs.Bosses;
using Console_Crawler.GameCharacters.HostileMobs.MiniBosses;

namespace Console_Crawler.GameCharacters
{
    internal class GameCharacter(string name, int attack, int armor, double strength, int health)
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
            public int StrenghtBuffTurns { get; set; } = 0;
        }
        public EffectsBools Effects { get; set; } = new EffectsBools();
        public AllEffectTurns EffectTurns { get; set; } = new AllEffectTurns();

        public virtual void NormalAttack(GameCharacter target)
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

        public void ApplyOverTimeEffects(GameCharacter enemy)
        {
            this.ApplyPoisonDamage(enemy);
            this.ApplyBurnDamage(enemy);
        }

        public void ApplyPoisonDamage(GameCharacter enemy)
        {
            if (this.EffectTurns.PoisonTurns > 0)
            {

                if (enemy is GiantSpider giantSpider)
                {
                    this.Health -= giantSpider.PoisonDamage;
                }
                
                if (enemy is Spider spider)
                {
                    this.Health -= spider.PoisonDamage;
                }
                this.EffectTurns.PoisonTurns--;
            }
            else
            {
                this.Effects.IsPoisoned = false;
            }
        }

        public void ApplyBurnDamage(GameCharacter enemy)
        {
            if (this.EffectTurns.BurnTurns > 0)
            {
                if (enemy is Dragon dragon)
                {
                    this.Health -= dragon.BurnDamage;
                }
                
                if(enemy is DemonicSorcerer sorcerer)
                {
                    this.Health -= sorcerer.BurnDamage;
                }
                this.EffectTurns.BurnTurns--;
            }
            else
            {
                this.Effects.IsBurning = false;
            }
        }

        public virtual void PrintBattleStats()
        {
            Console.WriteLine($" Name: {this.Name}");
            Console.WriteLine($" Health: {this.Health}");
            Console.WriteLine($" Armor: {this.Armor}");
        }

        public virtual void PrintStats()
        {
            Console.WriteLine($" Name: {this.Name}");
            Console.WriteLine($" Attack: {this.Attack}");
            Console.WriteLine($" Armor: {this.Armor}");
            Console.WriteLine($" Strength: {this.Strength}");
            Console.WriteLine($" Health: {this.Health}");
        }
    }
}
