
using Console_Crawler.GameCharacters;
using Console_Crawler.GameCharacters.HostileMobs.Bosses;
using Console_Crawler.GameCharacters.HostileMobs.MiniBosses;
using Console_Crawler.Items;
using Console_Crawler.Weapons;
using NUnit.Framework;

namespace Console_Crawler.DungeonBuilder.__tests__
{
    [TestFixture]
    internal class Dungeon_Test
    {
        [Test]
        public void Dungeon_Constructor_EasyDungeon_Test()
        {
            Dungeon dungeon = new Dungeon("Easy");
            Enemy[] enemies = dungeon.Rooms[0].Enemies;

            Assert.That(dungeon.Rooms.Length, Is.EqualTo(1));
            Assert.That(enemies.Length, Is.InRange(1, 3));
            Assert.That(dungeon.Chest.Gold, Is.InRange(5, 10));
            Assert.That(dungeon.Chest?.Items?.Length, Is.EqualTo(null).Or.EqualTo(1));

            if(dungeon.Chest?.Items != null)
            {
                Assert.That(dungeon.Chest?.Items[0], Is.InstanceOf(typeof(Item)));
            }
            else
            {
                Assert.That(dungeon.Chest?.Items, Is.EqualTo(null));
            }
            Assert.That(dungeon.Chest?.Weapons, Is.EqualTo(null).Or.AssignableTo<Weapon>());
            Assert.That(dungeon.Rooms[0].IsLastRoom, Is.True);
            Assert.That(dungeon.Rooms[0].Enemies[0], Is.Not.InstanceOf(typeof(Dragon)));
            Assert.That(dungeon.Rooms[0].Enemies[0], Is.Not.InstanceOf(typeof(GiantSpider)));
            Assert.That(dungeon.Rooms[0].Enemies[0], Is.Not.InstanceOf(typeof(DemonicSorcerer)));
        }

        [Test]
        public void Dungeon_Constructor_MediumDungeon_Test()
        {
            Dungeon dungeon = new Dungeon("Medium");

            Assert.That(dungeon.Rooms.Length, Is.EqualTo(2));
            
            foreach(Room room in dungeon.Rooms)
            {
                Assert.That(room.Enemies.Length, Is.InRange(3, 5));
            }

            if(dungeon.Chest?.Items != null)
            {
                Assert.That(dungeon.Chest?.Items?.Length, Is.InRange(2, 3));
                foreach(Item item in dungeon.Chest.Items)
                {
                    Assert.That(item, Is.InstanceOf(typeof(Item)));
                }
            }
            else
            {
                Assert.That(dungeon.Chest?.Items, Is.EqualTo(null));
            }

            Assert.That(dungeon.Chest.Gold, Is.InRange(10, 20));
            Assert.That(dungeon.Chest?.Weapons, Is.EqualTo(null).Or.AssignableTo<Weapon>());

            Assert.That(dungeon.Rooms[dungeon.Rooms.Length - 1].IsLastRoom, Is.True);
        }

        [Test]
        public void Dungeon_Constructor_HardDungeon_Test()
        {
            Dungeon dungeon = new Dungeon("Hard");
            
            Assert.That(dungeon.Rooms.Length, Is.EqualTo(3));

            foreach(Room room in dungeon.Rooms)
            {
                Assert.That(room.Enemies.Length, Is.InRange(5, 10));
            }

            if(dungeon.Chest?.Items != null)
            {
                Assert.That(dungeon.Chest?.Items?.Length, Is.InRange(3, 4));
                foreach(Item item in dungeon.Chest.Items)
                {
                    Assert.That(item, Is.InstanceOf(typeof(Item)));
                }
            }
            else
            {
                Assert.That(dungeon.Chest?.Items, Is.EqualTo(null));
            }

            Assert.That(dungeon.Chest.Gold, Is.InRange(20, 30));
            Assert.That(dungeon.Chest?.Weapons, Is.EqualTo(null).Or.AssignableTo<Weapon>());

            Assert.That(dungeon.Rooms[dungeon.Rooms.Length - 1].IsLastRoom, Is.True);
        }

        [Test]
        public void Dungeon_Constructor_BossDungeon_Test()
        {
            Dungeon dungeon = new Dungeon("Boss");
             
            Assert.That(dungeon.Rooms.Length, Is.EqualTo(5));
            foreach(Room room in dungeon.Rooms)
            {
                Assert.That(room.Enemies.Length, Is.InRange(10, 20));
            }

            if(dungeon.Chest?.Items != null)
            {
                Assert.That(dungeon.Chest?.Items?.Length, Is.InRange(4, 5));
                foreach(Item item in dungeon.Chest.Items)
                {
                    Assert.That(item, Is.InstanceOf(typeof(Item)));
                }
            }
            else
            {
                Assert.That(dungeon.Chest?.Items, Is.EqualTo(null));
            }

            Assert.That(dungeon.Chest.Gold, Is.InRange(30, 80));
            Assert.That(dungeon.Chest?.Weapons, Is.EqualTo(null).Or.AssignableTo<Weapon>());
            
            // check if last room is boss room and if last enemy is dragon
            Assert.That(dungeon.Rooms[dungeon.Rooms.Length - 1].IsLastRoom, Is.True);
            Assert.That(dungeon.Rooms[dungeon.Rooms.Length - 1].Enemies[dungeon.Rooms[dungeon.Rooms.Length - 1].Enemies.Length - 1], Is.AssignableTo<Dragon>());
        }
    }
}
