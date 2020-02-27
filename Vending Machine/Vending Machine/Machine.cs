using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class Machine
    {

        int insertedMoney;

        public int InsertedMoney { get { return insertedMoney; } set { insertedMoney = value; } }

        Dictionary<string, Stack<Product>> allProducts = new Dictionary<string, Stack<Product>>();



        public Machine()
        {
            allProducts.Add("CocaCola", new Stack<Product>());
            allProducts.Add("Fanta", new Stack<Product>());
            allProducts.Add("Cocio", new Stack<Product>());
            allProducts.Add("Faxecondi", new Stack<Product>());
            allProducts.Add("Corny", new Stack<Product>());
            allProducts.Add("Snickers", new Stack<Product>());
            allProducts.Add("Twix", new Stack<Product>());
            allProducts.Add("Redbull", new Stack<Product>());
            allProducts.Add("ColaEnergy", new Stack<Product>());
            allProducts.Add("Snackbar", new Stack<Product>());

            Fill();

        }




        void Fill()
        {
            for (int i = 0; i < 10; i++)
            {
                allProducts["CocaCola"].Push(new Product("Cola", 21));
            }
            for (int i = 0; i < 10; i++)
            {
                allProducts["Fanta"].Push(new Product("Fanta",  20));
            }
            for (int i = 0; i < 10; i++)
            {
                allProducts["Cocio"].Push(new Product("Cocio", 12));
            }
            for (int i = 0; i < 10; i++)
            {
                allProducts["Faxecondi"].Push(new Product("Faxecondi", 20));
            }
            for (int i = 0; i < 10; i++)
            {
                allProducts["Corny"].Push(new Product("Corny", 14));
            }
            for (int i = 0; i < 10; i++)
            {
                allProducts["Snickers"].Push(new Product("Snickers", 17));
            }
            for (int i = 0; i < 10; i++)
            {
                allProducts["Twix"].Push(new Product("Twix", 15));
            }
            for (int i = 0; i < 10; i++)
            {
                allProducts["Redbull"].Push(new Product("Redbul", 35));
            }
            for (int i = 0; i < 10; i++)
            {
                allProducts["ColaEnergy"].Push(new Product("CocaCola Energy", 23));
            }
            for (int i = 0; i < 10; i++)
            {
                allProducts["Snackbar"].Push(new Product("Snackbar", 16));
            }
        }

        public void AvailableProducts()
        {
            Console.WriteLine("-------------------------");
            foreach (var item in allProducts)
            {
                if (item.Value.Count > 0)
                {
                    Console.WriteLine("{0}, {1}kr", item.Value.Peek().Name, item.Value.Peek().Price);
                }
            }

            Console.WriteLine("-------------------------");

        }

        public void PurchaseProduct()
        {
            Console.WriteLine("Indtast tallet ved den ting du vil købe");
            int input = Int32.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    RemoveProduct(allProducts["CocaCola"]);
                    break;
                case 2:
                    RemoveProduct(allProducts["Fanta"]);
                    break;
                case 3:
                    RemoveProduct(allProducts["Cocio"]);
                    break;
                case 4:
                    RemoveProduct(allProducts["Faxecondi"]);
                    break;
                default:
                    break;
            }
        }

        public void RemoveProduct(Stack<Product> product)
        {
            int productprice = product.Peek().Price;
            if (productprice > insertedMoney)
            {
                Console.WriteLine("Du har ikke råd til dette produkt");
                return;
            }
            else if(productprice < insertedMoney)
            {
                Console.WriteLine("Der er flere penge tilbage, giver byttepenge");
                insertedMoney = insertedMoney - productprice;

                product.Pop();

            }
            else
            {
                insertedMoney = insertedMoney - productprice;
                product.Pop();
            }
        }


    }
}
