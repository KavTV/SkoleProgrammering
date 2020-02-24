using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaskemaskine
{
    class Program
    {
        static void Main(string[] args)
        {
            Washingmachine Wash = new Washingmachine();
            while (true)
            {
                Console.WriteLine(Environment.NewLine + "Tænd/Sluk(1) Fill(2) Wash(3) ECO Wash(4) Spin(5)");
                int input = Int32.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Wash.TurnItOn();
                        break;
                    case 2:
                        Wash.Fill();
                        break;
                    case 3:Wash.WashMethod();
                        break;
                    case 4:Wash.EcoWash();
                        break;
                    case 5:Wash.Spin();
                        break;
                    
                    default: return;

                }
            }

            

        }
    }
}
