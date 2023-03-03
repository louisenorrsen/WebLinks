using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace WebLinks
{
    class Link
    {
        public string namn, url, info;

        public Link(string Namn, string Url, string Info)
        {
            namn = Namn;
            url = Url;
            info = Info;
        }
    }
    internal class Program
    {
        static Link[] links = new Link[0];
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            LoadFile();

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
                else if (command == "add")
                {
                    LoadFile();
                    AddURL();
                }
                else if (command == "load")
                {
                    LoadFile();
                }
                else if (command == "list")
                {
                    LoadFile();
                    ListURL();
                }
                else if (command == "open")
                {
                    LoadFile();
                    string link;
                    bool validLink;
                    do
                    {
                        Console.Write("Name: ");
                        link = Console.ReadLine();
                        if (link == null || link == "" || !DoesNameExistAlready(link))
                        {
                            Console.WriteLine("Write valid link name!");
                            validLink = false;
                        }
                        else
                        {
                            validLink = true;
                        }
                    } while (!validLink);

                    for (int i = 0; i < links.Length; i++)
                    {
                        if (link.ToLower() == links[i].namn.ToLower()) OpenURL(links[i].url);
                    }
                }
                else if (command == "check")
                {
                    Console.Write("Link: ");
                    string linkUrl = Console.ReadLine();
                    Console.WriteLine(DoesNameExistAlready(linkUrl));
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
            Console.WriteLine("Hello and welcome to the link program,");
            Console.WriteLine("that opens and adds links.");
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

            string[] filRader = File.ReadAllLines("weblinks.txt");

            links = new Link[filRader.Length];

            for (int i = 0; i < filRader.Length; i++)

            {
                string[] rad = filRader[i].Split('|');
                string namn = rad[0];
                string url = rad[1];
                string info = rad[2];

                Link newLink = new Link(namn, url, info);

                links[i] = newLink;

                //Console.WriteLine($"{rad[1]}");
            }

        }

        private static void ListURL()
        {
            //string[] urls = new string[] { "https://www.svt.se", "https://www.sr.se" };

            for (int i = 0; i < links.Length; i++)
            {
                string name = string.Empty;
                name = links[i].namn;
                string info = links[i].info;

                Console.WriteLine($"{i+1} : {name} - {info}");
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
            AddFunction.addFunction();
        }

        public static bool DoesNameExistAlready(string frågandeNamn)
        {
            for(int i = 0; i < links.Length; i++)
            {
                string namn = links[i].namn;
                if (namn.ToLower() == frågandeNamn.ToLower())
                {
                    return true;
                }
            }

            return false;
        }
    }
}