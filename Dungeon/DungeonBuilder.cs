using Console_Crawler.GameVariables;

namespace Console_Crawler.Dungeon
{
    internal class Dungeon
    {
        public Room[] Rooms { get; set; }
        public Chest Chest { get; set; }
        public bool IsBossDungeon { get; set; }
        public int TotalRooms { get; set; }

        public Dungeon(string difficulty)
        {
            this.Rooms = GenerateRooms(difficulty);
            this.Chest = GenerateChest(difficulty);
            this.IsBossDungeon = difficulty == "Boss" ? true : false;
            this.TotalRooms = this.Rooms.Length;
        }

        private static int GetRoomCount(string difficulty)
        {
            return DungeonSettings.GetRoomCount(difficulty);
        }

        private static Room[] GenerateRooms(string difficulty)
        {
            int roomCount = GetRoomCount(difficulty);
            Room[] rooms = new Room[roomCount];
            for (int i = 0; i < roomCount; i++)
            {
                bool isLastRoom = i == roomCount - 1;

                rooms[i] = new Room(i + 1, difficulty, isLastRoom);
            }
            return rooms;
        }

        private Chest GenerateChest(string difficulty)
        {
            return new Chest(difficulty);
        }
    }
}
