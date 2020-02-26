using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnTurPåBiblioteket
{
    class Bog
    {

        int sides;
        bool hardCover;
        string category;
        string name;
        static List<Bog> Books = new List<Bog>();
        
        public int Sides
        {
            get { return sides; }
            set { sides = value; }
        }
        public bool HardCover { get => hardCover; set => hardCover = value; }
        public string Category { get => category; set => category = value; }
        public string Name { get => name; set => name = value; }

        public Bog()
        {

        }
        public Bog(string theName, int side, bool isHardCover, string Cat )
        {
            this.sides = side;
            this.hardCover = isHardCover;
            this.category = Cat;
            this.name = theName;
        }

        public void addBooks()
        {
            Books.Add(new Bog("Flyvende Jens",200,true,"Fantasy"));
            Books.Add(new Bog("Dragen der ikke kunne flyve", 50, false, "Fantasy" ));
            Books.Add(new Bog("Mordet",500, true, "Krimi" ));
            Books.Add(new Bog("Cisco network",10000, true, "Kedeligt" ));
            Books.Add(new Bog("Harry potter", 200, true, "Fantasy"));
            
        }

        public void ShowBooks()
        {
            foreach (var item in Books)
            {
                string hardCoverString = "Hårdt omslag";
                if (item.hardCover == true)
                {
                    hardCoverString = "Blødt omslag";
                }
                Console.WriteLine("{0}, er i kategorien {1} og har {2} sider og {3}", item.name, item.category, item.sides, hardCoverString);
            }
        }

        public Bog LendBook(string bookName)
        {
            
            foreach (var item in Books)
            {
                if (item.name == bookName)
                {
                    Books.Remove(item);
                    return item;
                }
            }

            return null;
        }
    }
}
