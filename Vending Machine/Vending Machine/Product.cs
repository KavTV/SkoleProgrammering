using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class Product
    {

        string name;
        int price;

        public string Name { get { return name; } set { name = value; } }
        public int Price{ get { return price; } set { price = value; } }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;

        }

    }
}
