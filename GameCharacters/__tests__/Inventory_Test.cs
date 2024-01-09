using Console_Crawler.GameVariables;
using Console_Crawler.Items;
using Console_Crawler.Items.Potions;
using NUnit.Framework;

namespace Console_Crawler.GameCharacters.__tests__
{
    [TestFixture]
    internal class Inventory_Test
    {
        [Test]
        public void Inventory_AddItem_Test()
        {
            //Arrange
            PlayerInventory inventory = new PlayerInventory();
            Item item = new Item("TestItem", "Test", "Desc", 1, 1);

            //Act
            inventory.AddItem(item);

            //Assert
            Assert.That(item, Is.EqualTo(inventory.Items[0]));
        }

        [Test]
        public void Inventory_AddItem_ExistingItem_Test()
        {
            //Arrange
            PlayerInventory inventory = new PlayerInventory();
            Item item = new Item("TestItem", "Test", "Desc", 1, 2);
            Item item2 = new Item("TestItem", "Test", "Desc", 1, 1);

            //Act
            inventory.AddItem(item);
            inventory.AddItem(item2);

            //Assert
            Assert.That(item.Quantity, Is.EqualTo(2));
        }

        [Test]
        public void Inventory_RemoveItem_Test()
        {
            //Arrange
            PlayerInventory inventory = new PlayerInventory();
            Item item = new Item("TestItem", "Test", "Desc", 1, 1);

            //Act
            inventory.AddItem(item);
            inventory.RemoveItem(item);

            //Assert
            Assert.That(inventory.Items.Count, Is.EqualTo(0));
        }

        [Test]
        public void Inventory_RemoveItem_ExistingItem_Test()
        {
            //Arrange
            PlayerInventory inventory = new PlayerInventory();
            Item item = new Item("TestItem", "Test", "Desc", 1, 2);
            Item item2 = new Item("TestItem", "Test", "Desc", 1, 1);

            //Act
            inventory.AddItem(item);
            inventory.AddItem(item2);
            inventory.RemoveItem(item2);

            //Assert
            Assert.That(item.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void Inventory_GetItemQuantity_Test()
        {
            //Arrange
            PlayerInventory inventory = new PlayerInventory();
            Item item = new Item("TestItem", "Test", "Desc", 1, 3);
            Item item2 = new Item("TestItem", "Test", "Desc", 1, 1);

            //Act
            inventory.AddItem(item);
            inventory.AddItem(item2);

            //Assert
            Assert.That(inventory.GetItemQuantity("Test"), Is.EqualTo(2));
        }

        [Test]
        public void Inventory_AddGold_Test()
        {
            //Arrange
            PlayerInventory inventory = new PlayerInventory();

            //Act
            inventory.AddGold(10);

            //Assert
            Assert.That(inventory.Gold, Is.EqualTo(10));
        }

        [Test]
        public void Inventory_RemoveGold_Test()
        {
            //Arrange
            PlayerInventory inventory = new PlayerInventory();

            //Act
            inventory.AddGold(10);
            inventory.RemoveGold(5);

            //Assert
            Assert.That(inventory.Gold, Is.EqualTo(5));
        }

        [Test]
        public void Inventory_RemoveGold_RanAway_Test()
        {
            //Arrange
            PlayerInventory inventory = new PlayerInventory();

            //Act
            inventory.AddGold(10);
            GameBools.RanAway = true;
            inventory.RemoveGold();

            //Assert
            Assert.That(inventory.Gold, Is.EqualTo(5));
        }

        [Test]
        public void Inventory_RemoveGold_OverAmount_Test()
        {
            //Arrange
            PlayerInventory inventory = new PlayerInventory();

            //Act
            inventory.AddGold(10);
            inventory.RemoveGold(15);

            //Assert
            Assert.That(inventory.Gold, Is.EqualTo(0));
        }

        [Test]
        public void Inventory_CalculateMaxPotionsPurchasebale_NoPotion_Test()
        {
            //Arrange
            PlayerInventory inventory = new PlayerInventory();
            HealPotion potion = new HealPotion();

            //Act
            inventory.AddGold(100);
            string maxPotions = inventory.CalculateMaxPotionsPurchaseable(potion);

            //Assert
            Assert.That(Int32.Parse(maxPotions), Is.EqualTo(5));
        }

        [Test]
        public void Inventory_CalculateMaxPotionsPurchasebale_Potion_Test()
        {
            //Arrange
            PlayerInventory inventory = new PlayerInventory();
            HealPotion potion = new HealPotion();

            //Act
            inventory.AddGold(100);
            inventory.AddItem(potion);
            string maxPotions = inventory.CalculateMaxPotionsPurchaseable(potion);

            //Assert
            Assert.That(Int32.Parse(maxPotions), Is.EqualTo(4));
        }

        [Test]
        public void Inventory_CalculateMaxPotionsPurchasebale_NoGold_Test()
        {
            //Arrange
            PlayerInventory inventory = new PlayerInventory();
            HealPotion potion = new HealPotion();

            //Act
            inventory.AddGold(0);
            string maxPotions = inventory.CalculateMaxPotionsPurchaseable(potion);

            //Assert
            Assert.That(Int32.Parse(maxPotions), Is.EqualTo(0));
        }   
    }
}
