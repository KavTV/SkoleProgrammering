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
            User user = new User(50);
            while (true)
            {
                
            WelcomeMessage(user, machine);
                
            string input = Console.ReadLine();
            switch (input)
            {
                case "1": machine.PurchaseProduct();
                    break;
                case "2": InsertCoin(machine, user);
                    break;
                case "3":machine.AvailableProducts();
                    break;
                default:
                    break;
            }




            }

            
        }

        static void InsertCoin(Machine machine, User user)
        {
            Console.WriteLine("Skriv det antal du vil sætte ind");
            int input = Int32.Parse(Console.ReadLine());
            if (input <= user.Money)
            {
                machine.InsertedMoney = machine.InsertedMoney + input;
                user.Money = user.Money - input;
            }

        }

        private  static void WelcomeMessage(User user, Machine machine)
        {
            Console.WriteLine("Velkommen til automaten");
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Husk");
            Console.WriteLine("1. Vælg ting du vil købe");
            Console.WriteLine("2. Indsæt penge");
            Console.WriteLine("3. Se hvad der er tilbage i automaten");
            Console.WriteLine("Du har {0}kr tilbage", user.Money);
            Console.WriteLine("Der er {0}kr i maskinen",machine.InsertedMoney);

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
