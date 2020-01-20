using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Teht._1.ECsharp
{
    class Laatikko : INimi
    {
        public string Nimi { get; set; }
        public double MaxPaino { get; set; } = 100;
        public List<Esine> Esine1 { get; set; }
        int Luku = 0;
        public Laatikko()
        {
            Esine1 = new List<Esine>();
        }
        public string SuurinPaino
        {
            get
            {
                //Vertaillaan esineitä painavimman esineen saamiseksi.
                Esine1.Sort((a, b) => a.CompareTo(b));
                return (Esine1[Esine1.Count - 1]).ToString();
            }
        }
        public double LaatikkoPaino
        {
            get
            {
                double kg = Esine1.Select(i => i.Paino).Sum();
                return Math.Round(kg, 3);
            }
        }
        public void Uusiesine(Esine a)
        {
            //Vertaillaan painoja maksimipainon kanssa.
            //Maksimipainon ylittyessa nostetaan poikkeus.
            try
            {
                if (LaatikkoPaino > MaxPaino || a.Paino > MaxPaino || LaatikkoPaino + a.Paino > MaxPaino)
                {
                    throw new Exception();
                }
                if ( LaatikkoPaino <= MaxPaino && a.Paino > MaxPaino || LaatikkoPaino + a.Paino <= MaxPaino)
                {
                    Esine1.Add(a);
                    Luku++;
                }
            }
            catch (Exception)
            {
                WriteLine($"Laatikkoon {Nimi} ei voitu lisätä, koska maksimipaino olisi ylittynyt!");
            }
        }
        public override string ToString()
        {
            //Palautetaan laatikon nimi ja kokonaispaino.
            return ($"Laatikko {Nimi} {LaatikkoPaino} kg.");
        }
    }
}
