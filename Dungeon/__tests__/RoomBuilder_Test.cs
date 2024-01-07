using Console_Crawler.GameCharacters.HostileMobs.Bosses;
using NUnit.Framework;

namespace Console_Crawler.DungeonBuilder.__tests__
{
    [TestFixture]
    internal class RoomBuilder_Test
    {
        [Test]
        public void RoomBuilder_Constructor_Test()
        {
            Room room = new Room(1, "Easy", false);

            Assert.That(room.RoomNumber, Is.EqualTo(1));
            Assert.That(room.IsLastRoom, Is.False);
            Assert.That(room.Enemies.Length, Is.InRange(1, 3));
        }

        [Test]
        public void RoomBuilder_Constructor_BossRoom_Test()
        {
            Room room = new Room(1, "Boss", true);

            Assert.That(room.RoomNumber, Is.EqualTo(1));
            Assert.That(room.IsLastRoom, Is.True);
            Assert.That(room.Enemies.Length, Is.InRange(10, 20));
            Assert.That(room.Enemies[room.Enemies.Length - 1], Is.AssignableTo<Dragon>());
        }
    }
}
