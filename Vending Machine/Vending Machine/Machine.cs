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
        int allMoney;
        //EDIT PRICES FOR ITEMS
        int cocaColaPrice = 21;
        int fantaPrice = 20;
        int cocioPrice = 16;
        int faxecondiPrice = 19;
        int cornyPrice = 12;
        int snickersPrice = 15;
        int twixPrice = 15;
        int redbullPrice = 35;
        int colaEnergyPrice = 30;
        int snackbarPrice = 17;
        //

        public int InsertedMoney { get { return insertedMoney; } set { insertedMoney = value; } }
        public int AllMoney { get { return allMoney; } set { allMoney = value; } }

        Dictionary<string, Stack<Product>> allProducts = new Dictionary<string, Stack<Product>>();



        public Machine()
        {
            //Add all products into the dictionary
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




        public void Fill()
        {
            //Makes 10 new objects Product inside stack
            foreach (var item in allProducts)
            {
                //Making the price editable from the admin panel.
                int price = 5;
                if (item.Key == "CocaCola"){ price = cocaColaPrice;}
                if (item.Key == "Fanta") { price = fantaPrice; }
                if (item.Key == "Cocio") { price = cocioPrice; }
                if (item.Key == "Faxecondi") { price = faxecondiPrice; }
                if (item.Key == "Corny") { price = cornyPrice; }
                if (item.Key == "Snickers") { price = snickersPrice; }
                if (item.Key == "Twix") { price = twixPrice; }
                if (item.Key == "Redbull") { price = redbullPrice; }
                if (item.Key == "ColaEnergy") { price = colaEnergyPrice; }
                if (item.Key == "Snackbar") { price = snackbarPrice; }
                // Adds the amount of items needed to stock fully.
                int itemsToFill = 10 - item.Value.Count;
                for (int i = 0; i < itemsToFill; i++)
                {
                    allProducts[item.Key].Push(new Product(item.Key, price));
                }
            }
            
            
        }

        public void AvailableProducts()
        {
            //Checking for stacks inside dictionary, and peeking to see what item it is. Writes the item in writeline
            Console.WriteLine("-------------------------");
            int productNumber = 0;
            foreach (var item in allProducts)
            {
                productNumber++;
                if (item.Value.Count > 0)
                {
                    Console.WriteLine("{0}. {1}, {2}kr", productNumber,item.Value.Peek().Name, item.Value.Peek().Price);
                }
                else
                {
                    Console.WriteLine("{0}. Der er ikke flere {1}", productNumber, item.Key);
                }
            }

            Console.WriteLine("-------------------------");

        }

        public string SelectProduct()
        {
            Console.WriteLine("Indtast tallet ved den ting du vil købe");
            
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    return "CocaCola";
                case "2":
                    return "Fanta";
                case "3":
                    return "Cocio";
                case "4":
                    return "Faxecondi";
                case "5":
                    return "Corny";
                case "6":
                    return "Snickers";
                case "7":
                    return "Twix";
                case "8":
                    return "Redbull";
                case "9":
                    return "ColaEnergy";
                case "10":
                    return "Snackbar";
                default: 
                    return null;
            }
        }

        public Product PurchaseProduct(User user, string selectedProduct) //Purchase and move to user inventory
        {
            var product = allProducts[selectedProduct]; //Makes the product variable
            if (product.Count == 0)
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Der er ikke flere ting af dette produkt");
                Console.WriteLine("---------------------------------------");
                return null;// if no of the if statements return, then the product is not bought.
            }
            var productPeek = product.Peek(); //Because i pop before i return, i have to save the product before it is popped.

            int productprice = product.Peek().Price; // Makes it easier to get the product price.
            if (productprice > insertedMoney) //If not enough money, return null.
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Du har ikke råd til dette produkt");
                Console.WriteLine("---------------------------------------");
                return null;
            }
            else if(productprice < insertedMoney)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Der er flere penge tilbage, giver byttepenge");
                
                insertedMoney = insertedMoney - productprice;
                user.Money = user.Money + insertedMoney;
                insertedMoney = 0;
                allMoney = allMoney + productprice;
                product.Pop();
                return productPeek;
            }
            else if(productprice == insertedMoney)
            {
                insertedMoney = insertedMoney - productprice;
                allMoney = allMoney + productprice;
                product.Pop();
                return productPeek;
            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Der er ikke flere ting af dette produkt");
            Console.WriteLine("---------------------------------------");
            return null;// if no of the if statements return, then the product is not bought.
        }

        public void CancelOrder(User user) // if the admin wants to take all the money.
        {
            user.Money = user.Money + insertedMoney;
            insertedMoney = 0;
        }


    }
}
