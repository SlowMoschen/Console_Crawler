using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Crawler.Items
{
    internal class Item(string name, string type, string description, int price, int maxQuantity)
    {
        public string Name { get; set; } = name;
        public string Type { get; set; } = type;
        public string Description { get; set; } = description;
        public int Price { get; set; } = price;
        public int Quantity { get; set; } = 1;
        public int MaxQuantity { get; set; } = maxQuantity;
    }
}
