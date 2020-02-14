//MATIAS OJAKOSKI
using System;
using static System.Console;

namespace NoppaPeli
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kutsutaan Sovellus.Aja
            try
            {
                Sovellus.Aja();
            }
            //Jos suorituksen aikana nostetaan poikkeus, tulostetaan allaolevat tekstirivit
            catch (Exception e)
            {
                WriteLine("Ohjelman suoritus päättyi virheeseen.");
                WriteLine($"Virhe: {e.Message}");
                ReadKey();
            }
            WriteLine();
            WriteLine("Paina Enter lopettaaksesi...");
            ReadLine();
        }
    }
}