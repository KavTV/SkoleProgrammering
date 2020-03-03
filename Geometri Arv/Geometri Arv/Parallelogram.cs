using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri_Arv
{
    class Parallelogram : Rectangle
    {

        double angle;
        public Parallelogram(double sidea, double sideb, double angle)
        {
            Sidea = sidea;
            Sideb = sideb;
            this.angle = angle;
        }


        public override double Area()
        {
           double result = Sidea * Sideb * Math.Sin(angle*3.14/180);

           return result;
        }
        public override double Perimeter()
        {
            double result = 2 * Sidea + 2 * Sideb;
            return result;
        }

    }
}
