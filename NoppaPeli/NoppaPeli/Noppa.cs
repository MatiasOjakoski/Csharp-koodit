using System;

namespace NoppaPeli
{
    class Noppa
    {
        int _luku;
        static Random rand = new Random();
        int heitto = rand.Next(1, 7);

        public int Lukema { get; set; }
        public int HeittoLkm { get; set; }
        public Noppa(int heitto = 0)
        {
            HeittoLkm = heitto;
        }
        public int Heita()
        {
            _luku = rand.Next(1, 7);
            Lukema = _luku;
            HeittoLkm++;
            return Lukema;
        }
    }
}