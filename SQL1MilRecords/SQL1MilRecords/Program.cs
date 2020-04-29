using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SQL1MilRecords
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            FileStream fs = new FileStream(@"SQLTABLE1mil.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < 1000000; i++)
            {
                sw.WriteLine("{0}, {1}",i, random.Next(0,9999));
            }
            sw.Close();
            



        }
    }
}
