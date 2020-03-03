using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri_Arv
{
    class Rectangle : Shape
    {

        double sideb;
        
        public double Sideb { get => sideb; set => sideb = value; }

        public Rectangle(double sidea, double sideb)
        {
            Sidea = sidea;
            this.sideb = sideb;
        }


        public Rectangle() { }

        public override double Area()
        {
            double result = Sidea * sideb;
            return result;
        }

        public override double Perimeter()
        {
            return 2 * Sidea + 2 * sideb;
        }

    }
}
