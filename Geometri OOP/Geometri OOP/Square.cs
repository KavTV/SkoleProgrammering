using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri_OOP
{
    public class Square
    {
        double side = 0;

        // Lav en konstruktør
        public Square(double side)
        {
            this.side = side;
        }
        public Square()
        {
            
        }
        //property
        public double Side
        {
            get { return side; }
            set { side = value; }

        }
        //beregn omkreds og return
        public double Perimeter()
        {
            double result = this.side * 4;
            return result;
        }
        //beregn areal og return
        public double Area()
        {
            double result = this.side * this.side;
            return result;
        }
    }
}

