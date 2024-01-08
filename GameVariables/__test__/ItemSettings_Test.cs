using NUnit.Framework;

namespace Console_Crawler.GameVariables.__test__
{
    [TestFixture]
    internal class ItemSettings_Test
    {
        [Test]
        public void Get_All_Item_Prices()
        {
            string[] prices = ItemSettings.ItemPrice.GetAllItemPrices();

            Assert.That(prices.Length, Is.EqualTo(4));
            Assert.That(prices, Is.EquivalentTo(new string[] { "15G", "35G", "25G", "" }));
        }
    }
}
