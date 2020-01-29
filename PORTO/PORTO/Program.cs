using System;

namespace PORTO
{
    class Program
    {
        static void Main(string[] args)
        {
            int price = 0;
            string type = "";
            Console.WriteLine(Environment.NewLine + "Skriv længde i cm");
            double Length = double.Parse(Console.ReadLine());
            Console.WriteLine(Environment.NewLine + "Skriv bredde i cm");
            double Width = double.Parse(Console.ReadLine());
            Console.WriteLine(Environment.NewLine + "Skriv højde i cm");
            double Height = double.Parse(Console.ReadLine());
            Console.WriteLine(Environment.NewLine + "Skriv vægt i gram");
            double Weight = double.Parse(Console.ReadLine());
            Console.WriteLine(Environment.NewLine + "Skriv Land det skal sendes til ");
            string Country = Console.ReadLine();

            if (Length + Width + Height < 90)
            {
                type = "Brev";
                if (Country == "denmark")
                {

                
                if (Weight <= 50)
                {
                    price = 10;
                }
                else if (Weight <= 100)
                {
                    price = 20;
                }
                else if (Weight <= 250)
                {
                    price = 40;
                }
                
                else if (Weight <= 2000)
                {
                    price = 60;
                }
                else
                {
                    Console.WriteLine("Noget gik galt");
                }
                }
                else
                {
                    
                    if (Weight <= 100)
                    {
                        price = 30;
                    }
                    else if (Weight <= 250)
                    {
                        price = 60;
                    }
                    
                    else if (Weight <= 2000)
                    {
                        price = 90;
                    }
                    else
                    {
                        Console.WriteLine("Noget gik galt");
                    }
                }
            }
            else if(Length<= 120 && Length+(Length*Width*Height) > 300)
            {
                type = "Pakke";
                if (Country == "denmark")
                {

                if (Weight <= 2500)
                {
                    price = 50;
                }
                else if (Weight <= 5000)
                {
                    price = 60;
                }
                else if (Weight <= 10000)
                {
                    price = 80;
                }
                
                else if (Weight <= 20000)
                {
                    price = 100;
                }
                else if (Weight <= 35000)
                {
                    price = 160;
                }
                else
                {
                    Console.WriteLine("Noget gik galt");
                }
                }
                else
                {
                    if (Weight <= 1000)
                    {
                        price = 236;
                    }
                    else if (Weight <= 5000)
                    {
                        price = 315;
                    }
                    else if (Weight <= 10000)
                    {
                        price = 493;
                    }

                    else if (Weight <= 15000)
                    {
                        price = 638;
                    }
                    else if (Weight <= 20000)
                    {
                        price = 790;
                    }
                    else
                    {
                        Console.WriteLine("Noget gik galt");
                    }
                }
            }
            Console.WriteLine("Det vil koste "+price+" DKK at sende din/dit "+ type);
        }

    }
}
