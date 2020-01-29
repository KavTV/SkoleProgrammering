using System;
using System.Collections;
namespace opgave2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] DrengeNavne2 = {"william", "oliver", "noah", "emil", "victor", "magnus", "frederik", "mikkel", "lucas", "alexander", "oscar", "mathias", "sebastian", "malthe", "elias", "christian", "mads", "gustav", "benjamin", "kasper", };
            ArrayList DrengeNavne = new ArrayList();
            ArrayList PigeNavne = new ArrayList();
            for (int i = 0; i < DrengeNavne2.Length; i++)
            {
                DrengeNavne.Add(DrengeNavne2[i]);
            }
            Console.WriteLine("Vil du have alfabetisk orden (1), eller søge? (2)");
            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                DrengeNavne.Sort();

                for (int i = 0; i < DrengeNavne.Count; i++)
                {
                    Console.WriteLine(DrengeNavne[i]);
                }
            }
            while (true)
            {
                Console.WriteLine("Tilføj(1) slet(2) se liste(3)");
                string inputSearch = Console.ReadLine();
                if (inputSearch == "1")
                {
                    Console.WriteLine("Tilføj til Drenge(1) eller Pige(2) Listen?");
                    string inputlist = Console.ReadLine();
                    if (inputlist == "1")
                    {
                    string inputadd = Console.ReadLine();
                    DrengeNavne.Add(inputadd);
                    }
                    if (inputlist == "2")
                    {
                        string inputadd = Console.ReadLine();
                        PigeNavne.Add(inputadd);
                    }

                }
                else if(inputSearch == "2")
                {
                    Console.WriteLine("Fjern til Drenge(1) eller Pige(2) Listen?");
                    string inputlist = Console.ReadLine();
                    if (inputlist == "1")
                    {
                        string inputadd = Console.ReadLine();
                        DrengeNavne.Add(inputadd);
                    }
                    if (inputlist == "2")
                    {
                    string inputadd = Console.ReadLine();
                    PigeNavne.Remove(inputadd);
                    }
                }
                else
                {
                    DrengeNavne.Sort();
                    PigeNavne.Sort();
                    Console.WriteLine("---Drenge navne---");
                    for (int i = 0; i < DrengeNavne.Count; i++)
                    {
                        Console.WriteLine(DrengeNavne[i]);
                    }
                    Console.WriteLine("---Pige navne---");
                    for (int i = 0; i < PigeNavne.Count; i++)
                    {
                        Console.WriteLine(PigeNavne[i]);
                    }
                }
                

            }
            
                
            
        }
    }
}
