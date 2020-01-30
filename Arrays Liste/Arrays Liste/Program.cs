using System;
using System.Collections.Generic;

namespace Arrays_Liste
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listeB = new List<int>();
            List<int> listeReverse = new List<int>();

            for (int i = 0; i <= 20; i++)
            {
                if ((i % 2) == 0)
                {
                    listeB.Add(i);
                }
                

            }
            for (int i = 0; i < listeB.Count; i++)
            {
                if ((listeB[i] % 3) == 0)
                {
                    listeB.Remove(listeB[i]);
                }
            }
            for (int i = 0; i < listeB.Count; i++)
            {
                if (i == 2)
                {
                    listeB[i] = 17;
                }
            }

            int elements = 0;
            for (int i = 0; i < listeB.Count; i++)
            {
                elements++;
                Console.WriteLine(listeB[i]);
            }
            Console.WriteLine("Der er {0} elementer",elements);
            for (int i = 0; i < listeB.Count; i++)
            {
                listeReverse.Add(listeB[i]);
                
            }
            listeReverse.Reverse();
            for (int i = 0; i < listeReverse.Count; i++)
            {
                
                Console.WriteLine(listeReverse[i]);
            }
        }
    }
}
