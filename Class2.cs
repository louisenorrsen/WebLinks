using System;
using System.IO;

namespace WebLinks
{
    public static class AddFunction
    {
        public static void addFunction()
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine("vill du lägg till nya länkar? skriv J for ja elle N för nej");
            string svaret = Console.ReadLine();
            if (svaret == "J")
            {
                int grans = 0;
                Console.WriteLine("Hur många länkar vill du mata in=");
                grans = Int32.Parse((Console.ReadLine()));
                for (int i = 0; i < grans; i++)
                {
                    // det ska finnas en if satas här som kollar om namnet eller hemdsidan är redan finns. 
                    Console.WriteLine("Skriv namnet: ");
                    string namn = Console.ReadLine();
                    Console.WriteLine("Skriv kort beskrivning: ");
                    string beskrivning = Console.ReadLine();
                    Console.WriteLine("Skriv lanken, t.e. www.Google.com ");
                    string lanken = Console.ReadLine();
                    string[] nylank = { namn, beskrivning, lanken };
                    string inmatning = nylank[0] + "|" + nylank[1] + "|" + nylank[2];


                    using (StreamWriter sw = File.AppendText($@"{path}\linkList.list"))
                    {
                        sw.WriteLine(inmatning);
                    }
                    //File.WriteAllText($@"{path}\linkList.list", inmatning);


                }
                string[] txet = File.ReadAllLines($@"{path}\linkList.list");
                foreach (var line in txet)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine("Vill du lägga till mer länkar?");
                svaret = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Tack för att du använder vår tjänst.");
            }





        }
    }
}