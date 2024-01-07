
using Console_Crawler.GameCharacters;
using Console_Crawler.GameCharacters.HostileMobs.Bosses;
using Console_Crawler.Items;
using Console_Crawler.Weapons;
using NUnit.Framework;

namespace Console_Crawler.Dungeon.__tests__
{
    [TestFixture]
    internal class Dungeon_Test
    {
        [Test]
        public void Dungeon_Constructor_Test()
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
            Assert.That(dungeon.Rooms[dungeon.Rooms.Length - 1].IsBossRoom, Is.True);
            Assert.That(dungeon.Rooms[dungeon.Rooms.Length - 1].Enemies[dungeon.Rooms[dungeon.Rooms.Length - 1].Enemies.Length - 1], Is.AssignableTo<Dragon>());
        }
    }
}
