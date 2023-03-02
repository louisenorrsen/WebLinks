using System.ComponentModel.DataAnnotations;

namespace WebLinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintWelcome();
            string command;
            do
            {
                Console.Write(": ");
                command = Console.ReadLine();
                if (command == "quit")
                {
                    Console.WriteLine("Good bye!");
                }
                else if (command == "help")
                {
                    WriteTheHelp();
                }
                else if (command == "load")
                {
                    NotYetImplemented(command);
                }
                else if (command == "list")
                {
                    ListURLFromFile();
                }
                else if (command == "open")
                {
                    NotYetImplemented(command);
                }
                else
                {
                    Console.WriteLine($"Unknown command '{command}'");
                }
            } while (command != "quit");
        }

        private static void NotYetImplemented(string command)
        {
            Console.WriteLine($"Sorry: '{command}' is not yet implemented");
        }

        private static void PrintWelcome()
        {
            Console.WriteLine("Hello and welcome to the ... program ...");
            Console.WriteLine("that does ... something.");
            Console.WriteLine("Write 'help' for help!");
        }

        private static void WriteTheHelp()
        {
            string[] hstr = {
                "help  - display this help",
                "load  - load all links from a file",
                "open  - open a specific link",
                "quit  - quit the program"
            };
            foreach (string h in hstr) Console.WriteLine(h);
        }

        private static void LoadFile()
        {
            string fileName = "";
        }

        private static void ListURLFromFile()
        {
            string[] urls = new string[] { "https://www.svt.se", "https://www.sr.se" };

            for (int i = 0; i < urls.Length; i++)
            {
                string name = string.Empty;

                string[] contents = urls[i].Split('.');

                Console.WriteLine($"{i} : {contents[1]}");
            }
        }

        private static void OpenURL(string url)
        {

        }

        private static void AddURL()
        {

        }

        private static void SaveURL()
        {

        }
    }
}