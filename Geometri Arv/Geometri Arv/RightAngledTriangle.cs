using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri_Arv
{
    class RightAngledTriangle : Shape
    {
        double sideb;
        double sidec;
        
        public RightAngledTriangle(double sidea, double sideb, double sidec)
        {
            this.Sidea = sidea;
            this.sideb = sideb;
            this.sidec = sidec;
        }

        public override double Area()
        {
            double result = 0.5 * Sidea * sideb;
            
            return result;
        }
        public override double Perimeter()
        {
            return Sidea + sideb + sidec;
        }

    }
}
