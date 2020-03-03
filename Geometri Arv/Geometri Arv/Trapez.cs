using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri_Arv
{
    class Trapez : Rectangle
    {

        double sidec;
        double sided;
        

        public Trapez(double sidea, double sideb, double sidec, double sided)
        {
            Sidea = sidea;
            this.Sideb = sideb;
            this.sidec = sidec;
            this.sided = sided;
        }

        public override double Area()
        {
            double s = (Sidea + Sideb - sidec + sided) / 2;
            double h = 2 / (Sidea - sidec) * Math.Sqrt(s * (s - Sidea + sidec) * (s - Sideb) * (s - sided));
            double area = 0.5 * (Sidea + sidec) * h;
            return area;    
        }

        public override double Perimeter()
        {
            double result = Sidea + Sideb + sidec + sided;

            return result;
        }

    }
}
