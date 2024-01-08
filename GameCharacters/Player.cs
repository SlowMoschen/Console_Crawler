using Console_Crawler.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables;
using Console_Crawler.Items;
using Console_Crawler.GameVariables.Statistics.PlayerStatistics;
using Console_Crawler.GameVariables.Statistics;
using Console_Crawler.Items.Potions;
using Console_Crawler.GameUtilities.DisplayManager;

namespace Console_Crawler.GameCharacters
{
    internal class Player : GameCharacter
    {
        public Weapon CurrentWeapon { get; set; } = new Fists();
        public int Level { get; set; } = PlayerStats.Level;
        public int MaxLevel { get; set; } = PlayerStats.MaxLevel;
        public int EXP { get; set; } = PlayerStats.EXP;
        public int EXPToNextLevel { get; set; } = PlayerStats.EXPToNextLevel;
        public int MaxHealth { get; set; } = PlayerStats.InitialMaxHealth;
        public int Endurance { get; set; } = 100;
        public int MaxEndurance { get; set; } = 100;
        public PlayerInventory Inventory { get; set; } = new PlayerInventory();


        public Player(string name, int attack, int armor, double strength, int health) : base(name, attack, armor, strength, health) 
        { 
            this.SetAttackOptions();
        }

        public void EquipWeapon(Weapon weapon)
        {
            this.CurrentWeapon = weapon;
            this.SetAttackOptions();
        }

        //Method to calucalte 2 nums


        public void DecrementBuffTurns()
        {
            if(this.EffectTurns.StrenghtBuffTurns > 0)
            {
                this.EffectTurns.StrenghtBuffTurns--;

                if(this.EffectTurns.StrenghtBuffTurns == 0)
                {
                    this.Strength = PlayerStats.InitialStrength;
                }
            }
        }

        public void Rest()
        {
            GameStatistics.AddTotalRest();
            GameStatistics.AddTotalHealingDone(GameSettings.General.RestHealthRegen);
            this.Health += GameSettings.General.RestHealthRegen;
            this.Endurance += GameSettings.General.RestEnduranceRegen;

            if(this.Health > this.MaxHealth)
            {
                this.Health = this.MaxHealth;
            }

            if(this.Endurance > this.MaxEndurance)
            {
                this.Endurance = this.MaxEndurance;
            }
        }

        public override void NormalAttack(GameCharacter target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.CurrentWeapon.AttackDamage, target.Armor, this.Strength);

            if(this.Endurance >= this.CurrentWeapon.WeaponStats.EnduranceCost)
            {
                if(target.Effects.IsDefending)
                {
                    target.Effects.IsDefending = false;
                    return;
                }
                else
                {
                    GameStatistics.AddTotalDamageDealt(damage);
                    this.DealtDamage = damage;
                    target.Health -= damage;
                    this.Endurance -= this.CurrentWeapon.WeaponStats.EnduranceCost;
                }
            }
            else
            {
                Console.WriteLine(" You don't have enough endurance to attack!");
            }
        }

        public void KickAttack(GameCharacter target)
        {
            int damage = DamageCalculator.CalculateAttackDamage(this.Attack, target.Armor, this.Strength);
            this.DealtDamage = damage;

            if(this.Endurance >= GameSettings.General.KickEnduranceCost)
            {
                if(target.Effects.IsDefending)
                {
                    target.Effects.IsDefending = false;
                    return;
                }
                else
                {
                    GameStatistics.AddTotalDamageDealt(damage);
                    target.Health -= damage;
                    this.Endurance -= GameSettings.General.KickEnduranceCost;
                }
            }
            else
            {
                Console.WriteLine(" You don't have enough endurance to use a Kick Attack!");
            }
        }


        public void UseSpecialAttack(GameCharacter target)
        {
            if(this.CurrentWeapon != null)
            {
                this.CurrentWeapon.PerformSpecialAttack(this, target);
            }
        }

        public string ChooseAttack( Enemy target )
        {
            string attackChoice = DisplayManager.DisplayOptionsMenu(" What would you like to do?", MenuOptions.AttackOptions);

            var attackActions = new Dictionary<string, Action<Enemy>> {
                { "Normal Attack", this.NormalAttack },
                { this.CurrentWeapon?.WeaponStats?.SpecialAttackName, this.UseSpecialAttack },
                { "Kick Attack", this.KickAttack }
            };

            if (attackActions.TryGetValue(attackChoice, out var action))
            {
                action(target);
            }

            return attackChoice;
        }

        public void SetAttackOptions()
        {
            if(this.CurrentWeapon != null)
            {
                MenuOptions.AttackOptions = new string[] { "Normal Attack", CurrentWeapon.WeaponStats.SpecialAttackName, "Kick Attack" };
            }
        }

        public void LevelUp()
        {
            if(this.EXP >= this.EXPToNextLevel)
            {
                this.Level++;
                this.EXP = 0;
                this.EXPToNextLevel = this.Level * LevelUpModifers.EXPRating;
                this.Attack += LevelUpModifers.Attack;
                this.Armor += LevelUpModifers.Armor;
                this.MaxHealth = LevelUpModifers.MaxHealth * this.Level;
                this.Health = this.MaxHealth;
                this.Endurance = this.MaxEndurance;
                Console.WriteLine(" You leveled up!");
            }
        }

        public void AddEXP(int exp)
        {
            if(this.Level >= this.MaxLevel)
            {
                return;
            }

            this.EXP += exp;
            GameStatistics.AddTotalEXP(exp);
            
            if(this.EXP >= this.EXPToNextLevel)
            {
                this.LevelUp();
            }
        }

        public void BuyItem(Item item)
        {
            this.Inventory.RemoveGold(item.Price);
            this.Inventory.AddItem(item);
            GameStatistics.AddTotalItemBought();
        }

        public void UsePotion(string potionType)
        {
            Item? item = this.Inventory.GetExistingItem(potionType);

            if (item != null)
            {
                if(item is Potion)
                {
                    Potion potion = (Potion)item;
                    
                    switch(potion.Type)
                    {
                        case "Health Potion":
                            potion.UsePotion(this);
                            GameStatistics.AddTotalHealingDone(potion.EffectValue);
                            Console.WriteLine($" You used a {potion.Type} and healed for {potion.EffectValue} health.");
                            break;
                        case "Strength Potion":
                            potion.UsePotion(this);
                            Console.WriteLine($" You used a {potion.Type}, your next attacks will deal double the damage.");
                            break;
                        case "Endurance Potion":
                            potion.UsePotion(this);
                            Console.WriteLine($" You used a {potion.Type} and restored {potion.EffectValue} endurance.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine(" You don't have any of this potion!");
            }
        }

        public string ChoosePotion()
        {
           string[] itemsCount = this.Inventory.GetAllItemsCount();
           string[] itemNames = this.Inventory.GetAllItemsTypes();

           return InputHandler.GetChoice(" Which potion would you like to use?", itemNames, itemsCount);
        }

        public void RunFromBattle()
        {
            Console.WriteLine(" Running away will end the fight, but you get no Rewards and lose half of your Gold.");
            string input = InputHandler.GetChoice(" Do you want to run away?", new string[] { "Yes", "No" });

            if(input == "Yes")
            {
                Console.WriteLine(" You ran away from the fight!");
                this.Inventory.RemoveGold();
                GameBools.IsInBattle = false;
                GameBools.RanAway = true;
                GameBools.IsInMenu = true;
            }
            return;
        }

        public void PrintInventory()
        {
            this.Inventory.DisplayInventory();
        }

        public override void PrintStats()
        {
            base.PrintStats();
            Console.WriteLine($" Endurance: {this.Endurance}");
            Console.WriteLine($" Level: {this.Level}");
            Console.WriteLine($" EXP: {this.EXP}");
            Console.WriteLine($" EXP to Next Level: {this.EXPToNextLevel}");
        }

        public override void PrintBattleStats()
        {
            base.PrintBattleStats();
            Console.WriteLine($" Endurance: {this.Endurance}");

            if(this.EffectTurns.StrenghtBuffTurns > 0)
            {
                Console.WriteLine($" Strength is buffed for {this.EffectTurns.StrenghtBuffTurns} turns");
            }

            if(this.Effects.IsPoisoned)
            {
                Console.WriteLine($" Poisoned for {this.EffectTurns.PoisonTurns} turns");
            }

            if(this.Effects.IsBurning)
            {
                Console.WriteLine($" Burning for {this.EffectTurns.BurnTurns} turns");
            }
        }
    }
}
