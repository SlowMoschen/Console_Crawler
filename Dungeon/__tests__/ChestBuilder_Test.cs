using Console_Crawler.Items;
using Console_Crawler.Weapons;
using NUnit.Framework;

namespace Console_Crawler.DungeonBuilder.__tests__
{
    [TestFixture]
    internal class ChestBuilder_Test
    {
        [Test]
        public void Chest_Constructor_Test()
        {
            Chest chest = new Chest("Easy");

            Assert.That(chest.Gold, Is.InRange(5, 10));
            Assert.That(chest.Items?.Length, Is.EqualTo(null).Or.EqualTo(1));

            if(chest.Items != null)
            {
                Assert.That(chest.Items[0], Is.InstanceOf(typeof(Item)));
            }
            else
            {
                Assert.That(chest.Items, Is.EqualTo(null));
            }

            Assert.That(chest.Weapons, Is.EqualTo(null).Or.AssignableTo<Weapon>());
        }
    }
}
