using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri_Arv
{
    class Shape
    {

        double sidea = 0;
        //property
        public double Sidea
        {
            get { return sidea; }
            set { sidea = value; }

        }
        
        
        // Lav en konstruktør
        public Shape(double side)
        {
            Sidea = side;
        }
        public Shape()
        {

        }
        
        //beregn omkreds og return
        public virtual double Perimeter()
        {
            double result = this.sidea * 4;
            return result;
        }
        //beregn areal og return
        public virtual double Area()
        {
            double result = this.sidea * this.sidea;
            return result;
        }

    }
}
