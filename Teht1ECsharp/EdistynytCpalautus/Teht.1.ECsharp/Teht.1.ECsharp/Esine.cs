using System;

namespace Teht._1.ECsharp
{
    class Esine : INimi, IComparable<Esine>
    {
        public string Nimi { get; set; }
        public double PainoKg { get; set; }
        double kg;
        public double PainoG
        {
            get { return Paino * 1000; }
        }
        public double Paino
        {
            get
            {
                return kg;
            }
            set
            {
                if (value > 0)
                {
                    kg = Math.Round(value, 3);
                }
                else
                {
                    throw new Exception("Virhe.");
                }
            }
        }
        public override string ToString()
        {
            return $"{Nimi}, paino: {Paino}";
        }
        public int CompareTo(Esine other)
        {
            return Paino.CompareTo(other.Paino);
        }
    }
}
