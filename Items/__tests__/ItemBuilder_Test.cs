using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Crawler.Items.__tests__
{
    [TestFixture]
    internal class ItemBuilder_Test
    {
        [Test]
        public void Item_Constructor_Test()
        {
            Item item = new Item("Test Item", "Test Type", "Test Description", 100, 10);

            Assert.That(item.Name, Is.EqualTo("Test Item"));
            Assert.That(item.Type, Is.EqualTo("Test Type"));
            Assert.That(item.Description, Is.EqualTo("Test Description"));
            Assert.That(item.Price, Is.EqualTo(100));
            Assert.That(item.Quantity, Is.EqualTo(1));
            Assert.That(item.MaxQuantity, Is.EqualTo(10));
        }
    }
}
