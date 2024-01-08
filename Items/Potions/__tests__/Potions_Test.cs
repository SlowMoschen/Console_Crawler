using Console_Crawler.GameVariables;
using NUnit.Framework;

namespace Console_Crawler.Items.Potions.__tests__
{
    [TestFixture]
    internal class Potions_Test
    {
        [Test]
        public void HealPotion_Constructor_Test()
        {
            HealPotion potion = new HealPotion();

            Assert.That(potion.Quantity, Is.EqualTo(1));
            Assert.That(potion.EffectValue, Is.EqualTo(ItemSettings.ItemEffect.HealPotion));
            Assert.That(potion.MaxQuantity, Is.EqualTo(ItemSettings.ItemMaxQuantity.HealPotion));
            Assert.That(potion.Price, Is.EqualTo(ItemSettings.ItemPrice.HealPotion));
            Assert.That(potion.Name, Is.EqualTo("Heal Potion"));
            Assert.That(potion.Description, Is.EqualTo($"Heals the player for {potion.EffectValue} health."));
            Assert.That(potion.Type, Is.EqualTo("Health Potion"));
        }

        [Test]
        public void EndurancePotion_Constructor_Test()
        {
            EndurancePotion potion = new EndurancePotion();

            Assert.That(potion.EffectValue, Is.EqualTo(ItemSettings.ItemEffect.EndurancePotion));
            Assert.That(potion.MaxQuantity, Is.EqualTo(ItemSettings.ItemMaxQuantity.EndurancePotion));
            Assert.That(potion.Price, Is.EqualTo(ItemSettings.ItemPrice.EndurancePotion));
            Assert.That(potion.Name, Is.EqualTo("Endurance Potion"));
            Assert.That(potion.Description, Is.EqualTo($"Gives you {potion.EffectValue} endurance."));
            Assert.That(potion.Type, Is.EqualTo("Endurance Potion"));
        }

        [Test]
        public void StrengthPotion_Constructor_Test()
        {
            StrengthPotion potion = new StrengthPotion();

            Assert.That(potion.EffectValue, Is.EqualTo(ItemSettings.ItemEffect.StrengthPotion));
            Assert.That(potion.MaxQuantity, Is.EqualTo(ItemSettings.ItemMaxQuantity.StrengthPotion));
            Assert.That(potion.Price, Is.EqualTo(ItemSettings.ItemPrice.StrengthPotion));
            Assert.That(potion.Name, Is.EqualTo("Strength Potion"));
            Assert.That(potion.Description, Is.EqualTo("Your next attacks will deal double the damage"));
            Assert.That(potion.Type, Is.EqualTo("Strength Potion"));
        }
        
    }
}
