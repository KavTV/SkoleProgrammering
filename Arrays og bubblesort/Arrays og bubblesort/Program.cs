using System;

namespace Arrays_og_bubblesort
{
    class Program
    {
        static void Main(string[] args)
        {
            //Alle opgaver
            int[] array = new int[100];
            int temp = 0;
            Random random = new Random();
            //randomize array
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 100);
            }

            //make sure we stay within the array
            for (int j = 0; j < array.Length - 1; j++)
            {
                //run through elements and sort
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i+1])
                    {
                        //use temp to save array
                        temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                    }
                }
            }
            //Write array in console
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.WriteLine("--------");
            //sorts array in reverse
            Array.Reverse(array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
