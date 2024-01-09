using Console_Crawler.GameCharacters;
using Console_Crawler.GameVariables;
using Console_Crawler.GameUtilities;
using Console_Crawler.GameVariables.Statistics.EnemyStatistics;
using Console_Crawler.GameCharacters.HostileMobs;
using Console_Crawler.GameCharacters.HostileMobs.Bosses;
using Console_Crawler.GameCharacters.HostileMobs.MiniBosses;

namespace Console_Crawler.DungeonBuilder
{
    internal class Room
    {
        public int RoomNumber { get; set; }
        public bool IsLastRoom { get; set; }
        public Enemy[] Enemies { get; set; }

        public Room(int roomNumber, string difficulty, bool isLastRoom = false)
        {
            this.RoomNumber = roomNumber;
            this.IsLastRoom = isLastRoom;
            this.Enemies = GenerateRoomEnemies(difficulty);
        }

        private static int GetRoomEnemiesCount(string difficulty)
        {
            return DungeonSettings.GetRoomEnemiesCount(difficulty);
        }

        private Enemy[] GenerateRoomEnemies(string difficulty)
        {
            List<Enemy> enemies = new List<Enemy>();
            int enemyCount = GetRoomEnemiesCount(difficulty);

            for (int i = 0; i < enemyCount; i++)
            {
                
                if(difficulty == "Dev")
                {
                    enemies.Add(GetNormalEnemy("Stone Golem"));
                    break;
                }


                bool isMiniBoss = i == enemyCount - 1 && difficulty != "Easy" && this.IsLastRoom == false && Randomizer.GetChance(DungeonSettings.MiniBossSpawnRate);
                bool isBoss = i == enemyCount - 1 && difficulty == "Boss" && this.IsLastRoom == true;

                if (isMiniBoss)
                {
                    enemies.Add(GetMiniBoss());
                }
                else if (isBoss)
                {
                    enemies.Add(GetBoss());
                }
                else
                {
                    enemies.Add(GetNormalEnemy());
                }
            }

            return enemies.ToArray();
        }

        // @param enemyType: If specified, the method will return an enemy of the specified type - used for testing
        private static Enemy GetNormalEnemy(string enemyType = "")
        {
            // If no enemyType is specified, get a random enemyType
            if(enemyType == "")
            {
                string[] enemyTypes = DungeonSettings.EnemyTypes;
                enemyType = enemyTypes[Randomizer.GetRandomNumber(enemyTypes.Length)];
            }

            switch (enemyType)
            {
                case "Zombie":
                    return new Zombie(
                        name: "Zombie",
                        enemyStatistics: AllEnemyStatistics.Zombie
                        );
                case "Spider":
                    return new Spider(
                        name: "Spider",
                        enemyStatistics: AllEnemyStatistics.Spider
                        );
                case "Goblin":
                    return new Goblin(
                        name: "Goblin",
                        enemyStatistics: AllEnemyStatistics.Goblin
                        );
                case "Assassin":
                    return new Assassin(
                        name: "Assassin",
                        enemyStatistics: AllEnemyStatistics.Assassin
                        );
                case "Stone Golem":
                    return new StoneGolem(
                        name: "Stone Golem",
                        enemyStatistics: AllEnemyStatistics.StoneGolem
                        );
                default:
                    return new Zombie(
                        name: "Zombie",
                        enemyStatistics: AllEnemyStatistics.Zombie
                        );
            }
        }

        private static Enemy GetMiniBoss()
        {
            string[] miniBossTypes = DungeonSettings.MiniBossTypes;
            string miniBossType = miniBossTypes[Randomizer.GetRandomNumber(miniBossTypes.Length)];

            switch (miniBossType)
            {
                case "Giant Spider":
                    return new GiantSpider(
                        name: "Giant Spider",
                        enemyStatistics: AllEnemyStatistics.GiantSpider
                        );
                case "Demonic Sorcerer":
                    return new DemonicSorcerer(
                        name: "Demonic Sorcerer",
                        enemyStatistics: AllEnemyStatistics.DemonicSorcerer
                        );
                default:
                    return new GiantSpider(
                        name: "Giant Spider",
                        enemyStatistics: AllEnemyStatistics.GiantSpider
                        );
            }
        }

        private static Dragon GetBoss()
        {
            return new Dragon(
                    name: "Dragon",
                    enemyStatistics: AllEnemyStatistics.Dragon
                    );
        }
    }
}
