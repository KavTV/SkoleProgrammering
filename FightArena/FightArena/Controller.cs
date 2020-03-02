using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FightArena
{
    class Controller
    {



        static List<Hero> heroes = new List<Hero>();

        static void Main(string[] args)
        {
            //Add all heroes
            heroes.Add(new Hero("Kong Fu Harry", 120, 2, 2, 5, 5));
            heroes.Add(new Hero("Super hunden Dino", 70, 6, 8, 2, 8));
            heroes.Add(new Hero("Hurtig Karl", 90, 2, 5, 3, 3));
            heroes.Add(new Hero("Gift Gunner", 80, 1, 13, 3, 3));
            heroes.Add(new Hero("Minimusen Mikkel", 40, 9, 9, 9, 9));
            heroes.Add(new Hero("Katten Tiger", 35, 3, 6, 4, 4));
            heroes.Add(new Hero("Gummigeden", 70, 6, 6, 8, 8));
            heroes.Add(new Hero("elgen Egon", 90, 5, 11, 4, 4));
            //Did not have time to make the list/opponents randomized
            Arena arena = new Arena();
            //Returns the winner of each fight and place the winner to semi finals, and finals
            Hero fight1 = arena.StartFight(heroes[0], heroes[1]);
            Thread.Sleep(1000);
            Hero fight2 = arena.StartFight(heroes[2], heroes[3]);
            Thread.Sleep(1000);
            Hero fight3 = arena.StartFight(heroes[4], heroes[5]);
            Thread.Sleep(1000);
            Hero fight4 = arena.StartFight(heroes[6], heroes[7]);
            Thread.Sleep(1000);
            Hero semi1 = arena.StartFight(fight1, fight2);
            Thread.Sleep(1000);
            Hero semi2 = arena.StartFight(fight3, fight4);
            Thread.Sleep(1000);
            Hero final = arena.StartFight(semi1, semi2);
            //print who won the final
            Console.WriteLine("Vinderen er {0} !!", final.HeroName);

            Console.ReadLine();
        }

    }
}
