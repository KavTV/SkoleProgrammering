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
                Console.WriteLine("---Velkommen til automaten---");
                Console.WriteLine("Tryk enter for at simulere ny bruger...");
                Console.ReadLine();
                Random random = new Random();
                user = new User(random.Next(20,300)); // Every new user gets a random amount of money
                bool sameUser = true;
                while (sameUser)
                {
                    WelcomeMessage(user, machine);

                    string input = Console.ReadLine();
                    string selectedProduct = "";
                    //Switch to deside what option the user wants
                    switch (input)
                    {
                        case "1":
                            machine.AvailableProducts();
                            selectedProduct = machine.SelectProduct();
                            if (selectedProduct != null)
                            {
                                Product purchasedProduct = machine.PurchaseProduct(user, selectedProduct);
                                if (purchasedProduct != null)
                                {
                                    user.UserProducts.Add(purchasedProduct);
                                    Console.WriteLine("Du har købt {0}!", purchasedProduct.Name);
                                }
                            }
                            break;
                        case "2":
                            InsertCoin(machine, user);
                            break;
                        case "3":
                            machine.AvailableProducts();
                            break;
                        case "4":
                            if (user.UserProducts.Count == 0)
                            {
                                Console.WriteLine(Environment.NewLine + "Du har ikke købt nogen ting");
                            }
                            else
                            {
                                foreach (var item in user.UserProducts)
                                {
                                    Console.WriteLine(item.Name);
                                }
                            }
                            break;
                        case "5":
                            machine.CancelOrder(user);
                            break;
                        case "6":
                            AdminMenu(machine);
                            break;
                        case "7":
                            sameUser = false;
                            break;
                        default:
                            Console.WriteLine("Nummeret hører ikke til nogen ting");
                            break;
                    }




                }

            }
        }

        private static void AdminMenu(Machine machine)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("Administrator panel");
            Console.WriteLine("Automat har {0}kr liggende",machine.AllMoney);
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Fyld maskinen op");
            Console.WriteLine("2. Fjern penge fra maskinen");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    machine.Fill();
                    break;
                case "2":
                    machine.AllMoney = 0;
                    break;
                case "3":
                    break;
                default:
                    break;
            }

        }

        static void InsertCoin(Machine machine, User user)
        {
            Console.WriteLine("Skriv hvor mange kr du vil sætte ind");
            //Makes console string into int, but crashes if letter is written.
            int input = Int32.Parse(Console.ReadLine());
            //if input is lower or equal to users money it will insert them into the machine.
            if (input <= user.Money)
            {
                machine.InsertedMoney = machine.InsertedMoney + input;
                user.Money = user.Money - input;
            }
            //if Money to be inserted is higher than users money
            else
            {
                Console.WriteLine("Du har ikke nok penge");
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
            Console.WriteLine("3. Se hvad der er tilbage i automaten");
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
