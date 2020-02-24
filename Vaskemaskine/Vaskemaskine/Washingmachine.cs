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
            if (turnedon == false)
            {
                Console.WriteLine("Vaskemaskine ikke tændt");
                return;
            }
            for (int i = 10; i >= 1; i--)
            {
                Thread.Sleep(500);
                Console.WriteLine("Fylder vand i...{0}",i);
            }
        }

        public void WashMethod()
        {
            if (turnedon == false)
            {
                Console.WriteLine("Vaskemaskine ikke tændt");
                return;
            }
            for (int i = 15; i >= 1; i--)
            {
                Thread.Sleep(500);
                Console.WriteLine("Vasker...{0}", i);
            }
        }

        public void EcoWash()
        {
            if (turnedon == false)
            {
                Console.WriteLine("Vaskemaskine ikke tændt");
                return;
            }
            for (int i = 20; i >= 1; i--)
            {
                Thread.Sleep(500);
                Console.WriteLine("Eco Vasker...{0}", i);
            }
        }

        public void Spin()
        {
            if (turnedon == false)
            {
                Console.WriteLine("Vaskemaskine ikke tændt");
                return;
            }
            for (int i = 15; i >= 1; i--)
            {
                Thread.Sleep(500);
                Console.WriteLine("Drejer rundt...{0}", i);
            }
        }

    }
}
