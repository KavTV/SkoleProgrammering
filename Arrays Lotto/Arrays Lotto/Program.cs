using System;

namespace Arrays_Lotto
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] winningCoupon = new int[7];
            int[] userCoupon = new int[7];
            int match = 0;
            //Laver vinder kupon
            for (int i = 0; i < 7; i++)
            {
                winningCoupon[i] = random.Next(1, 21);
            }
            //Giver brugeren mulighed for at lave sin egen kupon
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("Indtast dit nummer");
                int input = int.Parse(Console.ReadLine());
                userCoupon[i] = input;
            }
            //tjekker om rækkerne passer med vinder koupon
            for (int i = 0; i < winningCoupon.Length; i++)
            {
                    if (winningCoupon[i] == userCoupon[i])
                    {
                        match++;
                    }
            }
            //udskriver vinder mulighederne
            if (match < 3)
            {
                Console.WriteLine("Du vandt ingenting :(");
            }
            else if (match < 5)
            {
                Console.WriteLine("Du har vundet en lille gevindst");
            }
            else if (match <= 7)
            {
                Console.WriteLine("Du vandt den store premie");
            }
            else
            {
                Console.WriteLine("Du vandt ingenting");
            }
        }
    }
}
