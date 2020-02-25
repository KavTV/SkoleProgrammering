using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFO_OOP
{
    class GUI
    {


        public void MainMenu()
        {
            People guestList = new People();
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Velkommen til KavTV's VIP PARTY");
            

           


            Console.WriteLine("Tilføj gæst(1) Slet gæst(2) Vis antal ting(3) Vis min max ting(4) Find ting (5) Udskriv gæsteliste(6) Luk(7)");
            int input = Int32.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.WriteLine("Skriv Navn på gæst");
                    string inputname = Console.ReadLine();
                    Console.WriteLine("Skriv alder på gæst");
                    int inputage = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Skriv køn på gæst");
                    string inputgender = Console.ReadLine();
                    People PeopleList = new People(inputname, inputage, inputgender);
                    break;
                case 2:
                    guestList.DeleteGuest();
                    break;
                case 3:
                    guestList.ShowNumberOfGuests();
                    break;
                case 4:
                    guestList.MinAndMax();
                    break;
                case 5:
                    guestList.FindGuests();
                    break;
                case 6:
                    guestList.ShowItems();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                    
                    
                default:
                    break;
            }
        }

    }
}
