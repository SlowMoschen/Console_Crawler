using Console_Crawler.Items.Potions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Crawler.Items.__tests__
{
    [TestFixture]
    internal class PotionBuilder_Test
    {
        [Test]
        public void Potion_Constructor_Test()
        {
            Potion potion = new Potion("Test Potion", "Test Type", "Test Description", 100, 10, 10);

            Assert.That(potion.Name, Is.EqualTo("Test Potion"));
            Assert.That(potion.Type, Is.EqualTo("Test Type"));
            Assert.That(potion.Description, Is.EqualTo("Test Description"));
            Assert.That(potion.Price, Is.EqualTo(100));
            Assert.That(potion.Quantity, Is.EqualTo(1));
            Assert.That(potion.MaxQuantity, Is.EqualTo(10));
            Assert.That(potion.EffectValue, Is.EqualTo(10));
        }   
    }
}
