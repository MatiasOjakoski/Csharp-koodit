using System;
using static System.Console;
using static Helpers.Syote;

namespace NoppaPeli
{
    static class Sovellus
    {
        static int VOITONPISTERAJA = 3;
        public static void Aja()
        {
            //Varsinainen pelin algoritmi
            //Kysyy pelaajien 1 ja 2 nimet ja perustaa niille Pelaaja-oliot
            //Perustaa Noppa-oliot
            WriteLine("Noppa-peli");
            string nimi1;
            nimi1 = Merkkijono("Pelaajan 1 nimi:");
            Noppa noppa1 = new Noppa();
            Noppa noppa2 = new Noppa();
            Pelaaja eka = new Pelaaja(nimi1);
            Console.Write("Pelaajan 2 nimi: ");
            Pelaaja toka = new Pelaaja(nimi: (Console.ReadLine()));
            do
            {
                //int n1 = ensimmäisen pelaajan nopanheittojen yhteenlaskettu tulos
                //int n2 = toisen pelaajan nopanheittojen yhteenlaskettu tulos
                int n1 = 0;
                int n2 = 0;

                noppa1.Heita();
                noppa2.Heita();
                n1 = noppa1.Lukema + noppa2.Lukema;
                WriteLine($"Heittokierros {noppa1.HeittoLkm}");
                Write($"{eka.Nimi}: ");
                WriteLine($"{noppa1.Lukema} + {noppa2.Lukema} = {n1}");
                Write($"{toka.Nimi}: ");

                noppa1.Heita();
                noppa2.Heita();
                n2 = noppa1.Lukema + noppa2.Lukema;

                WriteLine($"{noppa1.Lukema} + {noppa2.Lukema} = {n2}");

                noppa1.HeittoLkm--;

                //Pelaajien pisteiden laskeminen annettujen sääntöjen mukaisesti. Kierroksen häviäjän pisteet nollataan ja voittajan pisteitä nostetaan yhdellä
                //Kun jompikumpi pelaaja saavuttaa 3 pistettä, ohjelma kertoo voittajan nimen ja kuinka monta kierrosta pelattiin
                if (n1 > n2)
                {
                    eka.Pisteet++;
                    toka.Pisteet = 0;
                }
                if (n1 == n2)
                {
                }
                if (n2 > n1)
                {
                    toka.Pisteet++;
                    eka.Pisteet = 0;
                }
                if (eka.Pisteet == VOITONPISTERAJA || toka.Pisteet == VOITONPISTERAJA)
                {
                    break;
                }
                ReadKey();
            } while (true);
            if (eka.Pisteet == 3)
            {
                WriteLine();
                WriteLine($"Pelin voittaja on {eka.Nimi} ja noppia heitettiin {noppa1.HeittoLkm} kertaa!");
            }
            else
            {
                WriteLine();
                WriteLine($"Pelin voittaja on {toka.Nimi} ja noppia heitettiin {noppa1.HeittoLkm} kertaa!");
            }
        }
    }
}
