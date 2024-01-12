using Console_Crawler.GameUtilities;
using Console_Crawler.GameCharacters.HostileMobs;
using Console_Crawler.GameCharacters.HostileMobs.Bosses;
using Console_Crawler.GameCharacters.HostileMobs.MiniBosses;
using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.GameVariables.Statistics.PlayerStatistics;

namespace Console_Crawler.GameCharacters
{
    internal class GameCharacter(string name, int attack, int armor, double strength, int health)
    {
        public string Name { get; set; } = name;
        public int Attack { get; set; } = attack;
        public int Armor { get; set; } = armor;
        public double Strength { get; set; } = strength;
        public int Health { get; set; } = health;
        public int DealtDamage { get; set; } = 0;
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
            public int BuffedTurns { get; set; } = 0;
        }
        public EffectsBools Effects { get; set; } = new EffectsBools();
        public AllEffectTurns EffectTurns { get; set; } = new AllEffectTurns();

        public virtual void NormalAttack(GameCharacter target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength);
            if(target.Effects.IsDefending)
            {
                target.Effects.IsDefending = false;
                Console.WriteLine($" {this.Name} tried to attack you, but you successfully defended the attack!");
                return;
            }
            else 
            { 
                this.DealtDamage = damage;
                target.Health -= damage;

                Console.WriteLine($" {this.Name} attacked you for {damage} damage.");

                // Add damage to statistics - only counts for enemies because the NormalAttack Method is overriden in Player.cs
                GameStatistics.AddTotalDamageTaken(damage);
            }
        }

        public void ClearDealtDamage()
        {
            this.DealtDamage = 0;
        }

        public virtual void Defend()
        {
            this.Effects.IsDefending = true;
        }

        public virtual void DecrementBuffTurns()
        {
            if (this.EffectTurns.BuffedTurns > 0)
            {
                this.EffectTurns.BuffedTurns--;

                if (this.EffectTurns.BuffedTurns == 0)
                {
                    this.ResetBuffedStats();
                }
            }
        }

        // This Method will be overriden in Child Classes - will reset the stats that are buffed by the StrenghtBuff
        public virtual void ResetBuffedStats()
        {}

        public void ApplyOverTimeEffects(GameCharacter? enemy = null)
        {
            this.ApplyPoisonDamage(enemy);
            this.ApplyBurnDamage(enemy);
        }

        public void ApplyPoisonDamage( GameCharacter? enemy = null )
        {
            if (this.EffectTurns.PoisonTurns > 0)
            {
                if (enemy is GiantSpider giantSpider)
                {
                    this.Health -= giantSpider.PoisonDamage;
                    Console.WriteLine($" You took {giantSpider.PoisonDamage} poison damage.");
                    GameStatistics.AddTotalDamageDealt(giantSpider.PoisonDamage);
                }
                
                if (enemy is Spider spider)
                {
                    this.Health -= spider.PoisonDamage;
                    Console.WriteLine($" You took {spider.PoisonDamage} poison damage.");
                    GameStatistics.AddTotalDamageDealt(spider.PoisonDamage);
                }
                this.EffectTurns.PoisonTurns--;
            }
            else
            {
                this.Effects.IsPoisoned = false;
            }
        }

        public void ApplyBurnDamage(GameCharacter? enemy = null)
        {
            if (this.EffectTurns.BurnTurns > 0)
            {
                if (enemy is Dragon dragon)
                {
                    this.Health -= dragon.BurnDamage;
                    Console.WriteLine($" You took {dragon.BurnDamage} burn damage.");
                    GameStatistics.AddTotalDamageDealt(dragon.BurnDamage);
                }
                
                if(enemy is DemonicSorcerer sorcerer)
                {
                    this.Health -= sorcerer.BurnDamage;
                    Console.WriteLine($" You took {sorcerer.BurnDamage} burn damage.");
                    GameStatistics.AddTotalDamageDealt(sorcerer.BurnDamage);
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
