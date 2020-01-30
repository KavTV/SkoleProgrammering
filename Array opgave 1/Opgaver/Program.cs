using System;

namespace Opgaver
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Brugernavn = new string[5];
            string[] Password = new string[5];
            bool IsUsername = false;
            bool IsPassword = false;
            int tries = 0;
            int usernameIndex = 0;

            Brugernavn[0] = "jens";
            Brugernavn[1] = "kasper";
            Brugernavn[2] = "hans";
            Brugernavn[3] = "bo";
            Brugernavn[4] = "grete";

            Password[0] = "admin";
            Password[1] = "hejmeddig";
            Password[2] = "skrrt";
            Password[3] = "sovs";
            Password[4] = "nemt";

            Console.WriteLine("Skriv dit brugernavn:");
            string inputUsername = Console.ReadLine();

            // tjekker alle brugernavne i arrays og ser om der er noget der matcher input.
            for (int i = 0; i < Brugernavn.Length; i++)
            {
                if (Brugernavn[i] == inputUsername)
                {
                    usernameIndex = i;
                    IsUsername = true;
                }
                
            }
            //Kører while så man får muligheden for at indtaste kode 3 gange
            while (tries < 3 && IsPassword == false) {
                //ser om Brugernavn er skrevet korrekt
                if (IsUsername == true)
                {
                    Console.WriteLine(Environment.NewLine + "Skriv dit password");
                    string inputPassword = Console.ReadLine();
                    //ser om password med samme index som brugernavn passer med input.
                        if (Password[usernameIndex] == inputPassword)
                        {
                            IsPassword = true;
                        }
                    
                }
                else
                {
                    Console.WriteLine("Brugeren har ikke adgang");
                }

                if (IsPassword == true)
                {
                    Console.WriteLine("Adgang tilladt");
                }
                else
                {
                    tries++;
                    Console.WriteLine("adgangskode nægtet");
                }
            }
        }
    }
}
