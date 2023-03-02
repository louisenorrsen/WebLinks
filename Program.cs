using System.Diagnostics;

namespace WebLinks
{   
    class Links
    { }
    internal class Program
    {
        static string[] url = new string[0];
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
                    LoadFile();
                }
                else if (command == "list")
                {
                    ListURLFromFile();
                }
                else if (command == "open")
                {
                    Console.Write("Link: ");
                    string linkUrl = Console.ReadLine();
                    OpenURL(linkUrl);
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
            string fileName;
            url = File.ReadAllLines("weblinks.txt");

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
            Process proc = new Process();
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.FileName = url;
            proc.Start();
        }

        private static void AddURL()
        {

        }

        private static void SaveURL()
        {

        }
    }
}