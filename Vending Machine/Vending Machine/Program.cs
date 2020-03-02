using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {

            Machine machine = new Machine();
            User user = new User(150);
            while (true)
            {
                Console.Clear(); // New user does not want to see what the other guy bought
                Console.WriteLine("---Velkommen til automaten---");
                Console.WriteLine("Tryk enter for at bruge maskinen...");
                Console.ReadLine();
                Random random = new Random();
                user = new User(random.Next(50,300)); // Every new user gets a random amount of money, to simulate a new user with new inventory
                bool sameUser = true;
                while (sameUser)
                {
                    WelcomeMessage(user, machine);

                    string input = Console.ReadLine();
                    string selectedProduct = "";
                    //Switch to deside what option the user wants
                    switch (input) // i made it in a string so no matter what the user types, it will not crash
                    {
                        case "1":
                            selectedProduct = machine.SelectProduct(); //Gets a string with the item the user has selected
                            if (selectedProduct != null) // if string is not null purchase product
                            {
                                // this buys the product if enough money, and gives change to user, it then returns the product. So the user can get it in his inventory
                                Product purchasedProduct = machine.PurchaseProduct(user, selectedProduct); 
                                if (purchasedProduct != null)
                                {
                                    user.UserProducts.Add(purchasedProduct); // adds the purchased item, to user inventory. Every new user has a new inventory.
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Du har købt {0}!", purchasedProduct.Name);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                            }
                            break;
                        case "2":
                            machine.InsertMoney(user);
                            break;
                        case "3":
                            machine.AvailableProducts();
                            break;
                        case "4":
                            user.GetUserInventory();
                            break;
                        case "5":
                            machine.CancelOrder(user); //Returns money to user
                            break;
                        case "6":
                            AdminMenu(machine);
                            break;
                        case "7":
                            machine.CancelOrder(user); // Returns money to user before exiting.
                            sameUser = false; // ends the loop to enable a new user to use the machine. Every user has its own money and inventory
                            break;
                        default:
                            Console.WriteLine("Nummeret hører ikke til nogen ting");
                            break;
                    }




                }

            }
        }

        

        private static void AdminMenu(Machine machine) // This is where admins are able to maintain the machine
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("Administrator panel");
            Console.WriteLine("Automat har {0}kr liggende",machine.AllMoney);
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Fyld maskinen op");
            Console.WriteLine("2. Fjern penge fra maskinen");
            Console.WriteLine("3. Skift priser på ting");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    machine.Fill();
                    break;
                case "2":
                    machine.AllMoney = 0;
                    break;
                case "3": machine.ChangePrices();
                    break;
                default:
                    break;
            }

        }


        //Write all welcome messages here, for better overview
        private static void WelcomeMessage(User user, Machine machine)
        {
            //makes text red
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("1. Vælg den ting du vil købe");
            Console.WriteLine("2. Indsæt penge");
            Console.WriteLine("3. Se hvad der er i automaten");
            Console.WriteLine("4. Se de ting du har købt");
            Console.WriteLine("5. Få penge tilbage fra automat");
            Console.WriteLine("6. Admin. Menu");
            Console.WriteLine("7. Gå væk fra maskine");
            Console.WriteLine("Du har {0}kr tilbage i pungen", user.Money);
            Console.WriteLine("Der er {0}kr i maskinen", machine.InsertedMoney);

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
