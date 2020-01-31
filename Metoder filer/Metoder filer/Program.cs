using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Metoder_filer
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Add file(1) Delete file(2) Display files(3) Add Directory(4) Search File(5) Read text file(6) Søg efter filtype(7) Exit(8)");
                int input = int.Parse(Console.ReadLine());
                string input2 = "";
                string input3 = "";
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Skriv navn på filen...");
                        input2 = Console.ReadLine();
                        Console.WriteLine("Skriv text i filen...");
                        input3 = Console.ReadLine();
                        AddFile(input2, input3);
                        break;
                    case 2:
                        Console.WriteLine("Skriv navn på filen du vil slette...");
                        input2 = Console.ReadLine();
                        DeleteFile(input2);
                        break;
                    case 3:
                        
                        DisplayFiles();
                        break;
                    case 4:
                        Console.WriteLine("Skriv navn på folder...");
                        input2 = Console.ReadLine();
                        AddDirectory(input2);
                        break;
                    case 5:
                        Console.WriteLine("Skriv navn på filen du vil søge efter...");
                        input2 = Console.ReadLine();
                        SearchFile(input2);
                        break;
                    case 6:
                        Console.WriteLine("Skriv navnet på filen du vil læse...");
                        input2 = Console.ReadLine();
                        ReadTxtFile(input2);
                        break;
                    case 7:
                        Console.WriteLine("Skriv filtype du vil søge efter");
                        input2 = Console.ReadLine();
                        SearchFileType(input2);
                        break;
                    case 8:
                        exitConsole();
                        break;
                    default:
                        break;
                }
            }
            //opg1
            File.WriteAllText(@"StarWars.txt", "Han skød først");

            //opg2
            string content = File.ReadAllText(@"StarWars.txt");
            Console.WriteLine(content);
            //opg 3
            File.Delete(@"Starwars.txt");
            //opg4
            //AddDirectory();
            //return;
            //File.WriteAllText(@".\Droids\C3P0.txt", "i am intelligent");
            //File.WriteAllText(@".\Droids\R2D2.txt", "i am intelligent");

            ////opg5
            ////DeleteFile();
            ////opg6
            //Directory.CreateDirectory(@".\Droids\Astromech");
            //Directory.CreateDirectory(@".\Droids\Protocol");
            //File.WriteAllText(@".\Droids\Astromech\R2D2.txt", "beep boop");
            //File.WriteAllText(@".\Droids\Protocol\C3P0.txt", "sir");

            ////DisplayFiles();
            //Console.WriteLine("----------------");



            ////writer.WriteLine("Star Wars\nThe Empire Strikes Back\nReturn Of The Jedi\n");
            //List<string> actors = new List<string>()
            //{
            //    "Mark Hamill",
            //    "Harrison Ford",
            //    "Carrie Fisher"
            //};
            //for (int i = 0; i < actors.Count; i++)
            //{
            //    writer.WriteLine(actors[i]);
            //}
            //writer.Close();
            //ReadTxtFile();
            //return;

            Console.ReadKey();
        }

        private static void ReadTxtFile(string name)
        {
            //lav try catch, hvis brugeren skulle skrive forkert ind
            try
            {
            FileStream file;
            file = new FileStream(@".\"+name, FileMode.Open);
            var reader = new StreamReader(file);
                //læs indhold i tekstfil
            while (!reader.EndOfStream)
            {
                string read = reader.ReadLine();
                Console.WriteLine(read);
            }
            //luk streamreader
            reader.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("-------------");
                Console.WriteLine(e);
                Console.WriteLine("-------------");
            }
        }

        private static void AddDirectory(string name)
        {
            //sørg for at brugeren har skrevet noget
            if (name.Length > 0)
            {
            Directory.CreateDirectory(@".\"+name);
            }
        }

        private static void DisplayFiles()
        {
            //Finder alle filer i alle mapper og sub-mapper
            foreach (var directory in Directory.GetDirectories(@".\","*",SearchOption.AllDirectories))
            {
                Console.WriteLine(directory);
                foreach (var files in Directory.GetFiles(directory))
                {
                    Console.WriteLine(files);
                }
            }
        }

        private static void SearchFile(string name)
        {
            //      søger alle mapper igennem
            foreach (var directory in Directory.GetDirectories(@".\","*",SearchOption.AllDirectories))
            {   //      Finder alle filer og skriver filen ud hvis den passer med hvad brugeren har skrevet.
                foreach (var file in Directory.GetFiles(directory,"*",SearchOption.AllDirectories))
                {
                    string namedDirectory = "";
                    namedDirectory = directory + @"\" + name;
                    if (file == namedDirectory)
                {
                    Console.WriteLine("------------");
                    Console.WriteLine(file);
                    Console.WriteLine("------------");
                }
                }
            }
        }

        private static void DeleteFile(string file)
        {
            //sletter fil
            Directory.Delete(@".\"+file, true);
        }

        private static void AddFile(string name, string txt)
        {
            FileStream file;
            StreamWriter writer;
            //Laver en fil
            file = new FileStream(@".\"+name, FileMode.Create);
            //Åbner streamWriter
            writer = new StreamWriter(file);
            writer.WriteLine(txt);
        }

        static void SearchFileType(string pattern)
        {
            foreach (var item in Directory.GetFiles(@".\","*."+pattern,SearchOption.AllDirectories))
            {
                Console.WriteLine(item);
            }
        }
        static void exitConsole()
        {
            Environment.Exit(0);
        }
    }
}
