using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnTurPåBiblioteket
{
    class Program
    {
         static void Main(string[] args)
        {
            
                Book.addBooks();
            while (true)
            {
                Console.WriteLine("Vælg bog du vil låne(1) Se bøger der kan lånes(2) vis de bøger du vil låne(3) Lån valgte bøger(4)");
                int input1 = Int32.Parse(Console.ReadLine());
                switch (input1)
                {
                    case 1: LendSystem();
                        break;
                    case 2: Book.ShowBooks();
                        break;
                    case 3: showLend();
                        break;
                    case 4: LendOut();
                        break;
                    default:
                        break;
                }
                
                Console.WriteLine(Environment.NewLine);

            }


        }
           static Bog Book = new Bog();


        static Stack<Bog> BookStack = new Stack<Bog>();
        private static void LendSystem()
        {
            Console.WriteLine("Skriv navnet på bog");
            string bookName = Console.ReadLine();
            Bog lendTrue = Book.LendBook(bookName);
            if (lendTrue != null)
            {
                BookStack.Push(lendTrue);
                Console.WriteLine("------------");
                Console.WriteLine("Bog tilføjet til liste!");
                Console.WriteLine("------------");
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
        
        static void LendOut()
        {
            Console.WriteLine("Udlåner bøger...");
            for (int i = 0; i <= BookStack.Count; i++)
            {
                Console.WriteLine(BookStack.Peek().Name);
                BookStack.Pop();
            }
        }


    }
}
