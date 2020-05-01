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

                if (currentUser == null) // If no user is logged in, show login/signup menu
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
                    Console.Clear(); // makes sure the username and password gets cleared
                }
                else
                {
                    //Console.Clear();
                    switch (currentUser.Rights) //Depending on the rights you get different Menu's
                    {
                        case 1:
                            Console.WriteLine("Velkommen til administrator menu {0}", currentUser.Name);
                            AdminMenu();

                            break;
                        case 2:
                            Console.WriteLine("Velkommen til moderator menu {0}", currentUser.Name);
                            ModeratorMenu();

                            Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Velkommen til gæst menu {0}", currentUser.Name);
                            GuestMenu();
                            Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Noget gik galt, prøv at logge ind igen");
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
            if (usernameInput == "" || passwordInput.Length < 4 || nameInput == "") // If input is empty, or password is less that 4, return
            {
                Console.WriteLine("Et af dine felter er tomme");
                return;
            }


            lgc.CreateUser(usernameInput, passwordInput, nameInput);

        }

        static void Login() // Gets user input, calls Login Logic
        {
            string usernameInput = "";
            string passwordInput = "";
            try // Catch if input cant be read.
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
            currentUser = lgc.Login(usernameInput, passwordInput); // If credentials are right, return the User
        }

        private static void AdminMenu() // Shows this menu if the user has admin rights
        {
            //Do something an admin can
            Console.WriteLine("(1) For at se tabeller");
            Console.WriteLine("(2) For at oprette en tabel");
            Console.WriteLine("(3) For at opdatere brugers rettigheder");
            Console.WriteLine("(4) For at logge ud");
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
                case "4":
                    Logout();
                    break;
                default:
                    Console.WriteLine("Du har ikke valgt noget");
                    break;
            }
        }

        private static void ModeratorMenu() // shows this menu if User has moderator rights
        {
            // Do something a moderator can
            Console.WriteLine("(1) For at se tabeller");
            Console.WriteLine("(2) For at logge ud");
            string selectionInput = Console.ReadLine();
            switch (selectionInput)
            {
                case "1":
                    GetTables();
                    break;
                case "2": Logout();
                    break;
                default:
                    break;
            }
        }

        private static void GuestMenu() // Shows this menu if User is a guest
        {
            //Guests are not really allowed to do stuff
            Console.WriteLine("Du har ingen rettigheder!");

            Console.WriteLine("(1) For at logge ud");
            string selectionInput = Console.ReadLine();
            switch (selectionInput)
            {
                case "1":
                    Logout();
                    break;
                default:
                    break;
            }
        }

        private static void CreateTable() // Get required information to create a table
        {
            Console.WriteLine("Skriv tabel navn");
            string tableName = Console.ReadLine(); //Get user input

            Console.WriteLine("Skriv hvor mange colonner der skal være");
            int columns = Int32.Parse(Console.ReadLine()); // User puts amount of columns he want

            string[] columnName = new string[columns]; // Makes an array with amount of user requested columns
            string[] columnType = new string[columns];

            for (int i = 0; i < columns; i++) // For every column, ask for column name and column type
            {
                Console.WriteLine("Skriv navnet på colonne {0}", i + 1);
                columnName[i] = Console.ReadLine();

                Console.WriteLine("Skriv Typen på {0}", columnName[i]);
                columnType[i] = Console.ReadLine();
            }
            Logic lgc = new Logic();
            lgc.CreateTable(tableName, columns, columnName, columnType); // Create a table in database.
        }

        private static void GetTables() // Gets all the tables
        {
            Logic lgc = new Logic();
            lgc.GetTables();
        }

        private static void UpdateUserRights() // Updates the requested Users rights
        {
            Console.WriteLine("Skriv brugernavnet på bruger der skal oprettes");
            string usernameInput = Console.ReadLine();
            Console.WriteLine("Skriv rettigheden brugeren skal have.");
            Console.WriteLine("(1) Admin  (2) Moderator  (3) Gæst");
            string rightsInput = Console.ReadLine();

            Logic lgc = new Logic();
            lgc.UpdateUserRights(usernameInput, rightsInput);
        }

        private static void Logout() // Logs the user out
        {
            currentUser = null;
        }

    }
}
