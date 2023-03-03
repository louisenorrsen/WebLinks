﻿using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

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
                    AddURL();
                }
                else if (command == "load")
                {
                    LoadFile();
                }
                else if (command == "list")
                {
                    ListURL();
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
            AddFunction.addFunction();
        }
    }
}