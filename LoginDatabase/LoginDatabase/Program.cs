using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace LoginDatabase
{
    class Program
    {

        static User currentUser;
        static void Main(string[] args)
        {
            while (true)
            {

                if (currentUser == null)
                {
                    Console.WriteLine("(1) Login");
                    Console.WriteLine("(2) Opret bruger");
                    int input = Int32.Parse(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            Login();
                            break;
                        case 2:
                            CreateUser();
                            break;
                        default:
                            Console.WriteLine("Prøv igen");
                            break;
                    }
                }
                else
                {
                    //Console.Clear();
                    switch (currentUser.Rights)
                    {
                        case 1:
                            Console.WriteLine("Velkommen til administrator menu {0}", currentUser.Name);
                            AdminMenu();

                            break;
                        case 2:
                            Console.WriteLine("Velkommen til moderator menu {0}", currentUser.Name);


                            Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Velkommen til gæst menu {0}", currentUser.Name);
                            GuestMenu();
                            Console.ReadLine();
                            break;
                        default:
                            break;
                    }
                }



            }


        }

        static void CreateUser()
        {
            Logic lgc = new Logic();
            string usernameInput = "";
            string passwordInput = "";
            string nameInput = "";
            try // Get user input
            {
                Console.WriteLine("Skriv dit Brugernavn (Brugt til login)");
                usernameInput = Console.ReadLine();
                if (lgc.IsUsernameTaken(usernameInput) == true) // Check if username is taken.
                {
                    Console.WriteLine("Brugernavnet er allerede taget");
                    return;
                }
                if (usernameInput.Length > 50)
                {
                    Console.WriteLine("Brugernavn er for langt!");
                    return;
                }

                Console.WriteLine("Skriv dit Password");
                passwordInput = Console.ReadLine();
                if (passwordInput.Length > 50)
                {
                    Console.WriteLine("Password er for langt!");
                    return;
                }

                Console.WriteLine("Skriv dit Navn");
                nameInput = Console.ReadLine();
                if (nameInput.Length > 50)
                {
                    Console.WriteLine("Dit navn er for langt!");
                    return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.Clear();
            if (usernameInput == "" || passwordInput == "" || nameInput == "")
            {
                Console.WriteLine("Et af dine felter er tomme");
                return;
            }


            lgc.CreateUser(usernameInput, passwordInput, nameInput);

        }

        static void Login()
        {
            string usernameInput = "";
            string passwordInput = "";
            try
            {
                Console.WriteLine("Skriv dit Brugernavn (Brugt til login)");
                usernameInput = Console.ReadLine();

                Console.WriteLine("Skriv dit Password");
                passwordInput = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Logic lgc = new Logic();
            currentUser = lgc.Login(usernameInput, passwordInput);
        }

        private static void AdminMenu()
        {
            Console.WriteLine("(1) For at se tabeller");
            Console.WriteLine("(2) For at oprette en tabel");
            Console.WriteLine("(3) For at opdatere brugers rettigheder");
            string selectionInput = Console.ReadLine();
            switch (selectionInput)
            {
                case "1":
                    GetTables();
                    break;
                case "2":
                    CreateTable();
                    break;
                case "3":
                    UpdateUserRights();
                    break;
                default:
                    Console.WriteLine("Du har ikke valgt noget");
                    break;
            }
        }

        private static void ModeratorMenu()
        {

        }

        private static void GuestMenu()
        {
            Console.WriteLine("Du har ingen rettigheder");

        }

        private static void CreateTable() // Get required information to create a table
        {
            Console.WriteLine("Skriv tabel navn");
            string tableName = Console.ReadLine();

            Console.WriteLine("Skriv hvor mange colonner der skal være");
            int columns = Int32.Parse(Console.ReadLine());

            string[] columnName = new string[columns];
            string[] columnType = new string[columns];

            for (int i = 0; i < columns; i++)
            {
                Console.WriteLine("Skriv navnet på colonne {0}", i);
                columnName[i] = Console.ReadLine();

                Console.WriteLine("Skriv Typen på {0}", columnName[i]);
                columnType[i] = Console.ReadLine();
            }
            Logic lgc = new Logic();
            lgc.CreateTable(tableName, columns, columnName, columnType);
        }

        private static void GetTables()
        {
            Logic lgc = new Logic();
            lgc.GetTables();
        }

        private static void UpdateUserRights()
        {
            Console.WriteLine("Skriv brugernavnet på bruger der skal oprettes");
            string usernameInput = Console.ReadLine();
            Console.WriteLine("Skriv rettigheden brugeren skal have.");
            Console.WriteLine("(1) Admin  (2) Moderator  (3) Gæst");
            string rightsInput = Console.ReadLine();

            Logic lgc = new Logic();
            lgc.UpdateUserRights(usernameInput, rightsInput);
        }

    }
}
