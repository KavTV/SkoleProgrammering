using System;

namespace Array_opgave_5
{
    class Program
    {
        static void Main(string[] args)
        {
            float[,] array = new float[5, 5];
            int tableNumber = 1;
            for (int i = 0; i < 5; i++)
            {

            for (int j = 0; j < 5; j++)
            {
                array[i, j] = tableNumber;
                    tableNumber++;
            }

            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("  {0}  {1}  {2}  {3}  {4}",array[i,0], array[i, 1], array[i, 2], array[i, 3], array[i, 4]);
            }
        }
    }
}
