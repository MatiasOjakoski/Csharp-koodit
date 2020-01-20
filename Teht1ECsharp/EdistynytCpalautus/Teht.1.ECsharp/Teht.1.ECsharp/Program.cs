//Matias Ojakoski
using System;
using System.Collections.Generic;
using static System.Console;

//Ohjelma toimii suurinpiirtein ohjeen ja esimerkin mukaisesti.
//Ainoat puutteet, jotka itse löysin ja/tai en osannut ratkaista: Ohjelma ei nosta poikkeusta kun painoon ja/tai määrään
//syötetään negatiivinen luku. Ohjelma ei myöskään lopeta suorittamista negatiivisen määrän syöttämisen jälkeen.

namespace Teht._1.ECsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Laatikko> Laatikkolista;
            Laatikkolista = new List<Laatikko>();
            int LaatikkoLuku = 0;
            do
            {
                string TavaraPaino;
                double arvo;

                //Annetaan laatikolle nimi. Lisää uuden laatikon laatikoiden listaan.
                WriteLine("Anna laatikon nimi, tyhjä lopettaa:");
                string syote = ReadLine();
                if (syote.Length == 0)
                {
                    break;
                }
                Laatikkolista.Add(new Laatikko() { Nimi = syote });
                WriteLine("Lisää laatikkoon esineitä.");
                do
                {
                    //Annetaan esineelle nimi.
                    WriteLine("Anna lisättävän esineen nimi:");
                    string TNimi = ReadLine();
                    if (TNimi.Length == 0)
                    {
                        break;
                    }
                    do
                    {
                        //Annetaan esineelle paino. Ilmoitettava numeroilla.
                        WriteLine("Anna esineen paino (kg):");
                        TavaraPaino = ReadLine();
                        if (double.TryParse(TavaraPaino, out arvo))
                        {
                            break;
                        }
                        else
                        {
                            WriteLine("Käytä numeroita.");
                        }
                    } while (true);

                    string maara;
                    do
                    {
                        //Kuinka monta esinettä lisätään. Ilmoitettava numeroilla.
                        WriteLine("Lisättävä määrä:");
                        maara = ReadLine();
                        if (double.TryParse(maara, out arvo))
                        {
                            break;
                        }
                        else
                        {
                            WriteLine("Virhe. Ilmoita määrä numeroilla.");
                        }
                    } while (true);

                    double.Parse(TavaraPaino);
                    int lukum = 0;
                    try
                    {
                        while (lukum < int.Parse(maara))
                        {
                            //Tarkistetaan ylittääkö lisättyjen esineiden paino ja lukumäärä laatikon maksimipainon.
                            if (Laatikkolista[LaatikkoLuku].LaatikkoPaino + double.Parse(TavaraPaino) > 100)
                            {
                                break;
                            }
                            Laatikkolista[LaatikkoLuku].Uusiesine(new Esine() { Nimi = TNimi, Paino = double.Parse(TavaraPaino) });
                            lukum++;
                        }
                    }
                    catch (Exception)
                    {
                        WriteLine("Yritä uudelleen.");
                    }
                    finally
                    {
                        //Ilmoittaa montako esinettä lisättiin.
                        WriteLine($"Lisättiin {lukum} esinettä.");
                    }
                } while (true);

                LaatikkoLuku++;

            } while (true);
            //Kertoo jokaisen laatikon esineiden määrän, laatikon painon, painavimman esineen sekä painavimman esineen painon.
            foreach (Laatikko b in Laatikkolista)
                WriteLine($"{b.ToString()}\nEsineitä {b.Esine1.Count} kpl.\nPainavin esine {b.SuurinPaino} kg.\n");
            ReadLine();
        }
    }
}
