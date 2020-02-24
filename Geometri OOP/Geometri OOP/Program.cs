using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Skriv siden");
            double siden = double.Parse( Console.ReadLine());
            Square S = new Square(siden);
            Square D = new Square();

            double perimeter = S.Perimeter();
            double area = S.Area();
            Console.WriteLine(perimeter);
            Console.WriteLine(area);
            Console.WriteLine("--------------");
            Console.WriteLine(D.Perimeter());
            Console.WriteLine(D.Area());
            Console.ReadLine();

        }
    }
}
