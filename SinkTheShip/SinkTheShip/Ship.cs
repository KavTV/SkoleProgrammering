using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinkTheShip
{
    class Ship
    {
        int size;
        string name;
        public int Size { get => size; set => size = value; }
        public string Name { get => name; set => name = value; }

        public Ship(int size, string name) 
        {
            this.Size = size;
            this.name = name;
            
        }

    }
}
