using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryJediMindTricks
{
    class Program
    {
        static void Main(string[] args)
        {
            //Opret Dictionary
            Dictionary<string, int> people = new Dictionary<string, int>() { {"Jens",20 }, {"Han",70 } };
            //Tilføj til Dictionary
            people.Add("Kasper", 17);
            //First() finder den første ting inde i Dictionary people
            Console.WriteLine(people.First());

            people.Remove("Han");
            Console.WriteLine("--------------");
            foreach (var item in people)
            {
                Console.WriteLine("{0} er {1} år",item.Key, item.Value);
            }
            Console.WriteLine("--------------");
            Console.ReadLine();
        }
    }
}
