using System;

namespace Metoder_opgaver_lette
{
    class Program
    {
        static void Main(string[] args)
        {
            //Laver lommeregner efter aftale med Mikkel
            while (true)
            {
            Console.WriteLine("vil du plus(1) minus(2) gange(3) dividere(4) potens(5) Rod(6)");
            int input = int.Parse(Console.ReadLine());
            int tal1 = 0;
                int tal2 = 0;
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Indtast tal1");
                        tal1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Indtast tal2");
                        tal2 = int.Parse(Console.ReadLine());
                        Console.WriteLine(addNumbers(tal1, tal2));


                        break;
                    case 2:
                        Console.WriteLine("Indtast tal1");
                        tal1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Indtast tal2");
                        tal2 = int.Parse(Console.ReadLine());
                        Console.WriteLine(subtractNumber(tal1, tal2));
                        break;
                    case 3:
                        Console.WriteLine("Indtast tal1");
                        tal1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Indtast tal2");
                        tal2 = int.Parse(Console.ReadLine());
                        Console.WriteLine(timesNumber(tal1, tal2));
                        break;
                    case 4:
                        Console.WriteLine("Indtast tal1");
                        tal1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Indtast tal2");
                        tal2 = int.Parse(Console.ReadLine());
                        Console.WriteLine(devideNumber(tal1, tal2));
                        break;
                    case 5:
                        Console.WriteLine("Indtast tal1");
                        tal1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Indtast tal2");
                        tal2 = int.Parse(Console.ReadLine());
                        Console.WriteLine(potenscalc(tal1, tal2));
                        break;
                    case 6:
                        Console.WriteLine("Indtast tal1");
                        tal1 = int.Parse(Console.ReadLine());
                        Console.WriteLine(squarerootcalc(tal1));
                        break;
                    case 7:
                        Console.WriteLine("Indtast tal1");
                        tal1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Indtast tal2");
                        tal2 = int.Parse(Console.ReadLine());
                        Console.WriteLine(squarerootcalc(tal1));
                        break;
                    default:
                        break;
                }
            }

        }
        static double addNumbers(double tal1, double tal2)
        {
            double calc = tal1 + tal2;
            return calc;
        }

        static double subtractNumber(double tal1, double tal2)
        {
            double calc = tal1 - tal2;
            return calc;
        }
        static double timesNumber(double tal1, double tal2)
        {
            double calc = tal1 * tal2;
            return calc;
        }
        static double devideNumber(double tal1, double tal2)
        {
            double calc = tal1 / tal2;
            return calc;
        }

        static double potenscalc(double tal1,double tal2)
        {
            double calc = Math.Pow(tal1, tal2);
            return calc;
        }
        static double squarerootcalc(double tal1)
        {
            double calc = Math.Sqrt(tal1);
            return calc;
        }
        static double modulus(double tal1, double tal2)
        {
            double calc = tal1 % tal2;
            return calc;
        }


    }
}
