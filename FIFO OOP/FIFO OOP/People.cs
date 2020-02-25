using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFO_OOP
{
    class People
    {
        string name;
        int age;
        string gender;
        //opretter queue
        static Queue<People> Que = new Queue<People>();

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Gender { get => gender; set => gender = value; }

        //default konstruktør
        public People() { }

        //Opretter en gæst i queue
        public People(string theName,int theAge, string theGender)
        {
            Name = theName;
            Age = theAge;
            Gender = theGender;
            Que.Enqueue(this);

        }

        public void DeleteGuest()
        {
            Console.WriteLine("----------------");
            //Peek bliver brugt til at se det næste i køen 
            Console.WriteLine("{0} bliver slettet...", Que.Peek());
            Que.Dequeue();
            Console.WriteLine("----------------");
        }
        //Tæller alt der er i QUEUE
        public void ShowNumberOfGuests()
        {
            int counter = 0;
            Console.WriteLine("----------------");
            foreach (var item in Que)
            {
                counter++;
            }
            Console.WriteLine(counter);
            Console.WriteLine("----------------");
        }
        //Ser efter det højeste og laveste inde i Que.age
        public void MinAndMax()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("Den ældste gæst er: {0}",Que.Max(Que => Que.age));
            Console.WriteLine("Den yngste gæst er: {0}", Que.Min(Que => Que.age));
            Console.WriteLine("----------------");
        }

        public void FindGuests()
        {
            string inputname = Console.ReadLine();
            foreach (var item in Que)
            {
                //Kører foreach til at finde det brugeren har søgt efter
                if (item.name == inputname)
                {
                    Console.WriteLine("----------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(item.name);
                    Console.WriteLine(item.age);
                    Console.WriteLine(item.gender);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("----------------");
                }
            }
        }

        public void ShowItems()
        {
            Console.WriteLine("----------------");
            foreach (var item in Que)
            {
                Console.WriteLine("{0}, {1}, {2}", item.name, item.Age, item.gender);
            }
            Console.WriteLine("----------------");
        }

    }
}
