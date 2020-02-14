using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoppaPeli
{
    class Pelaaja : INimi
    {
        public string Nimi { get; }
        public int Pisteet { get; set; }

        public Pelaaja(string nimi)
        {
            Nimi = nimi;
            Pisteet = 0;
        }
    }
}