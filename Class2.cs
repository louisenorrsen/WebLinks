using System;
using System.IO;

namespace WebLinks
{
    public static class AddFunction
    {
        public static void addFunction()
        {
            string path = Environment.CurrentDirectory + "\\weblinks.txt";
            //string path = Directory.GetCurrentDirectory();
            Console.WriteLine("vill du lägg till nya länkar? skriv J for ja elle N för nej");
            string svaret = Console.ReadLine();
            if (svaret == "J")
            {
                int grans = 0;
                Console.WriteLine("Hur många länkar vill du mata in=");
                grans = Int32.Parse((Console.ReadLine()));
                int i = 0;
                while (i <grans)
                {

                
                    {
                        // det ska finnas en if satas här som kollar om namnet eller hemdsidan är redan finns. 
                        
                    Console.WriteLine("Skriv namnet: ");
                    string namn = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(namn) == true)
                    {
                        Console.WriteLine("Du skrev inget namn");
                        continue;
                        //using (StreamWriter sw = File.AppendText(path))
                        //{ sw.WriteLine(inmatning); }
                    }

                    if (Program.DoesNameExistAlready(namn) == true)
                    {
                        Console.WriteLine("Du skrev ett namn som redan finns, skriv om ett nytt");
                        continue;
                    }

                    
                    

                    Console.WriteLine("Skriv kort beskrivning: ");
                    string beskrivning = Console.ReadLine();


                    Console.WriteLine("Skriv lanken, t.e. www.Google.com ");
                    string lanken = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(lanken) == true)
                        {
                            Console.WriteLine("Du skrev inget lank");
                            continue;
                            //using (StreamWriter sw = File.AppendText(path))
                            //{ sw.WriteLine(inmatning); }
                        }

                        if (Program.DoesNameExistAlready(lanken) == true)
                        {
                            Console.WriteLine("Du skrev ett lank som redan finns, skriv om ett nytt");
                            continue;
                        }
                        string[] nylank = { namn, beskrivning, lanken };
                        string inmatning = nylank[0] + "|" + nylank[2] + "|" + nylank[1];
                        using (StreamWriter sw = File.AppendText(path))
                        { sw.WriteLine(inmatning); }


                        i++;
                        //File.WriteAllText($@"{path}\linkList.list", inmatning);
                }

                }
               /* string[] txet = File.ReadAllLines(path);
                foreach (var line in txet)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine("Vill du lägga till mer länkar?");
                svaret = Console.ReadLine();*/
            }
            else
            {
                Console.WriteLine("Tack för att du använder vår tjänst.");
            }





        }
    }
}
    