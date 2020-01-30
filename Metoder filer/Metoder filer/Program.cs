using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Metoder_filer
{
    class Program
    {
        static void Main(string[] args)
        {
            //opg1
            File.WriteAllText(@"StarWars.txt", "Han skød først");

            //opg2
            string content = File.ReadAllText(@"StarWars.txt");
            Console.WriteLine(content);
            //opg 3
            File.Delete(@"Starwars.txt");
            //opg4
            Directory.CreateDirectory(@".\Droids");
            File.WriteAllText(@".\Droids\C3P0.txt", "i am intelligent");
            File.WriteAllText(@".\Droids\R2D2.txt", "i am intelligent");
            //opg5
            Directory.Delete(@".\Droids", true);
            //opg6
            foreach (var item in Directory.GetFiles(@".\Droids\"))
            {
                Console.WriteLine(item);
            }


            Console.ReadKey();
        }
    }
}
