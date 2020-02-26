using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnTurPåBiblioteket
{
    class Program
    {
           static Bog Book = new Bog();
        static void Main(string[] args)
        {
            
                Book.addBooks();
            while (true)
            {
                Console.WriteLine("Vælg bog du vil låne(1) Se bøger der kan lånes(2) vis dine lånte bøger(3) Lån valgte bøger(4)");
                int input1 = Int32.Parse(Console.ReadLine());
                switch (input1)
                {
                    case 1: LendSystem();
                        break;
                    case 2: Book.ShowBooks();
                        break;
                    case 3: showLend();
                        break;
                    case 4: 
                        break;
                    default:
                        break;
                }
                
                Console.WriteLine(Environment.NewLine);

            }


        }


        static Stack<Bog> BookStack = new Stack<Bog>();
        private static void LendSystem()
        {
            Console.WriteLine("Skriv navnet på bog");
            string bookName = Console.ReadLine();
            Bog lendTrue = Book.LendBook(bookName);
            if (lendTrue != null)
            {
                BookStack.Push(lendTrue);
                Console.WriteLine("Bog lånt ud!");
            }
            else
            {
                Console.WriteLine("Kunne ikke finde nogle bog");
            }
        }

        static void showLend()
        {
            Console.WriteLine(Environment.NewLine);
            foreach (var item in BookStack)
            {
                Console.WriteLine(item.Name);
            }
        }
        

    }
}
