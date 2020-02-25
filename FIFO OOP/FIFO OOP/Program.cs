using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFO_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            GUI UI = new GUI();
            
            //Tilføjer lige noget ASCII ART
            Console.WriteLine(@" ____  __.           _______________   ____
|    |/ _|____ ___  _\__    ___/\   \ /   /
|      < \__  \\  \/ / |    |    \   Y   / 
|    |  \ / __ \\   /  |    |     \     /  
|____|__ (____  /\_/   |____|      \___/   
        \/    \/                           ");
            Console.WriteLine(@"____   ____._____________ 
\   \ /   /|   \______   \
 \   Y   / |   ||     ___/
  \     /  |   ||    |    
   \___/   |___||____|    
                         ");


            while (true)
            {
            UI.MainMenu();

            }
            





            Console.ReadLine();
        }
    }
}
