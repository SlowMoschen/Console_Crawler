using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics.Builder;

namespace Console_Crawler.GameVariables.Statistics.EnemyStatistics
{
    internal class AllEnemyStatistics
    {

        //**
        //** Normal Enemies
        //**

        public static Builder.EnemyStatistics Zombie = new Builder.EnemyStatistics(
            baseAttack: 10,
            baseArmor: 10,
            strength: 1.0,
            baseHealth: 110,
            baseEXP: 10,
            Gold: 5
            );

        public static SpiderStatistics Spider = new SpiderStatistics(
            baseAttack: 10,
            baseArmor: 20,
            strength: 1.0,
            baseHealth: 110,
            baseEXP: 30,
            Gold: 10,
            basePoisonDamage: 5,
            poisonChance: 25
            );

        public static GoblinStatistics Goblin = new GoblinStatistics(
            baseAttack: 5,
            baseArmor: 20,
            strength: 1.0,
            baseHealth: 120,
            baseEXP: 20,
            Gold: 15,
            stealAmount: 3
            );

        public static Builder.EnemyStatistics Assassin = new Builder.EnemyStatistics(
            baseAttack: 20,
            baseArmor: 5,
            strength: 1.0,
            baseHealth: 100,
            baseEXP: 40,
            Gold: 5
            );

        public static StoneGolemStatistics StoneGolem = new StoneGolemStatistics(
            baseAttack: 20,
            baseArmor: 35,
            strength: 1.0,
            baseHealth: 300,
            baseEXP: 50,
            Gold: 20,
            stunChance: 20
            );

        //**
        //** Mini Bosses
        //**

        public static GiantSpiderStatistics GiantSpider = new GiantSpiderStatistics(
            baseAttack: 20,
            baseArmor: 10,
            strength: 1.0,
            baseHealth: 350,
            baseEXP: 200,
            Gold: 50,
            basePoisonDamage: 10,
            poisonChance: 25,
            baseWebShotDamage: 15,
            stunChance: 25,
            basePoisonBiteDamage: 10
            );

        public static DemonicSorcererStatistics DemonicSorcerer = new DemonicSorcererStatistics(
            baseAttack: 35,
            baseArmor: 10,
            strength: 1.0,
            baseHealth: 500,
            baseEXP: 200,
            Gold: 50,
            baseHellFireBlastDamage: 20,
            burnChance: 15,
            burnDamage: 10,
            darkPacktAttackPercentage: 0.2,
            darkPacktHealthPercentage: 0.1
            );

        //**
        //** Bosses
        //**

        public static DragonStatistics Dragon = new DragonStatistics(
            baseAttack: 150,
            baseArmor: 35,
            strength: 1.5,
            baseHealth: 1200,
            baseEXP: 1200,
            Gold: 350,
            fireBreathDamage: 35,
            burnDamage: 10,
            burnChance: 33,
            rockThrowDamage: 30,
            stunChance: 25,
            tailStrikeDamage: 45
            );
    }
}
