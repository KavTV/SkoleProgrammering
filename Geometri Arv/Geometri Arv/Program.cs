using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri_Arv
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Shape(4));
            shapes.Add(new Rectangle(4,6));
            shapes.Add(new Trapez(10,9,8,9));
            shapes.Add(new Parallelogram(3,5,20));
            shapes.Add(new RightAngledTriangle(5,5,6));
            
            foreach (var item in shapes)
            {
                string getType = item.GetType().ToString();
                string[] typeSplit = getType.Split('.');
                
                Console.WriteLine(typeSplit[1]);
                Console.WriteLine("Areal");
                Console.WriteLine(item.Area());
                Console.WriteLine("omkreds");
                Console.WriteLine(item.Perimeter());
                Console.WriteLine(Environment.NewLine);
            }


            Console.ReadLine();
        }
    }
}
