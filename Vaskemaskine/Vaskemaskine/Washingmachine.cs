using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Vaskemaskine
{
    public class Washingmachine
    {
        bool turnedon;
        

        public void TurnItOn()
        {
            //slukker hvis maskinen er tændt og tænder hvis den er slukket
            if (turnedon == true)
            {
                turnedon = false;
                Console.WriteLine("Vaskemaskine slukkes");
            }
            else
            {
                turnedon = true;
                Console.WriteLine("Vaskemaskine tændt");
            }
            
        }
        

        public void Fill()
        {
            //sender tilbage hvis vaskemaskinen ikke er tændt
            if (turnedon == false)
            {
                Console.WriteLine("Vaskemaskine ikke tændt");
                return;
            }
            //tæller ned
            for (int i = 10; i >= 1; i--)
            {
                Thread.Sleep(500);
                Console.WriteLine("Fylder vand i...{0}",i);
            }
        }

        public void WashMethod()
        {
            //sender tilbage hvis vaskemaskinen ikke er tændt
            if (turnedon == false)
            {
                Console.WriteLine("Vaskemaskine ikke tændt");
                return;
            }
            //tæller ned
            for (int i = 15; i >= 1; i--)
            {
                Thread.Sleep(500);
                Console.WriteLine("Vasker...{0}", i);
            }
        }

        public void EcoWash()
        {
            //sender tilbage hvis vaskemaskinen ikke er tændt
            if (turnedon == false)
            {
                Console.WriteLine("Vaskemaskine ikke tændt");
                return;
            }
            //tæller ned
            for (int i = 20; i >= 1; i--)
            {
                Thread.Sleep(500);
                Console.WriteLine("Eco Vasker...{0}", i);
            }
        }

        public void Spin()
        {
            //sender tilbage hvis vaskemaskinen ikke er tændt
            if (turnedon == false)
            {
                Console.WriteLine("Vaskemaskine ikke tændt");
                return;
            }
            //tæller ned
            for (int i = 15; i >= 1; i--)
            {
                Thread.Sleep(500);
                Console.WriteLine("Drejer rundt...{0}", i);
            }
        }

    }
}
