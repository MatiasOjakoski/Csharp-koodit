using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LuhninAlgoritmi
{
    class Program
    {
        static void Main(string[] args)
        {
            //int kelvollisille ja virheellisille numerosarjoille.
            int kelvollinen = 0;
            int virheellinen = 0;
            do
            {
                WriteLine("Anna numerosarja: ");
                string numerosarja = ReadLine();
                if (numerosarja.Length == 0)
                {
                    break;
                }
                try
                {
                    //Tarkistaa Luhnin Algoritmiin kuuluvan tarkistenumeron avulla, onko numerosarja kelvollinen, vai virheellinen.
                    //Mikäli numerosarja on kelvollinen, lisää ohjelma yhden kelvollisiin. Mikäli virheellinen, lisää ohjelma yhden virheellisiin.
                    //Mikäli syöte ei ole numerosarja, ei ohjelma laske sitä virheellisiin numerosarjoihin.
                    if (LuhnTarkistus(LuhnAlgoritmi(numerosarja)) == Tarkistenumero(numerosarja))
                    {
                        WriteLine("Syöte on kelvollinen numerosarja. ");
                        kelvollinen++;
                    }
                    else
                    {
                        WriteLine("Syöte on virheellinen numerosarja. ");
                        virheellinen++;
                    }
                }               
                catch
                {
                    WriteLine("Syöte ei ole numerosarja!");
                }
            } while (true);
            WriteLine($"Kelvollisia numerosarjoja: {kelvollinen}");
            WriteLine($"Virheellisiä numerosarjoja: {virheellinen}");
            ReadLine();
        }
        static string LuhnAlgoritmi(string numerosarja)
        {
            //Luhnin Algoritmi.
            //Lasketaan algoritmin mukainen summa.
            int kerrointarkistus = 1;
            int numero = 0;
            int laskutoimitus = 0;
            string str = "";
            for (int i = numerosarja.Length - 2; i > -1; i--)
            {
                if (kerrointarkistus % 2 <= 0)
                {
                    numero = int.Parse($"{numerosarja[i]}") * 1;
                    laskutoimitus = laskutoimitus + numero;
                }
                else
                {
                    //Kertoo parittomat(järjestyksessä) luvut kahdella.
                    numero = int.Parse($"{numerosarja[i]}") * 2;
                    //Mikäli luvusta tulee kaksinumeroinen(yli yhdeksän), erotetaan luvun ensimmäinen ja toinen numero ja lasketaan ne yhteen
                    // käyttäen Convert.ToString, ToString ja int.TryParsea.
                    //Ensiksi luvut muunnetaan string-muotoon, jolloin numerot saadaan erilleen.
                    //Tämän jälkeen muunnetaan erilliset luvut int-muotoon ja toteutetaan niiden laskutoimitus Luhnin Algoritmin mukaisesti.
                    if (numero > 9)
                    {
                        string str1 = Convert.ToString(numero);
                        string str2 = str1[0].ToString();
                        string str3 = str1[1].ToString();
                        int luku1 = 0;
                        int luku2 = 0;
                        Int32.TryParse(str2, out luku1);
                        Int32.TryParse(str3, out luku2);
                        laskutoimitus = laskutoimitus + (luku1 + luku2);
                    }
                    else
                    {
                        //Mikäli luku ei ole kaksinumeroinen(Ylitä yhdeksää), laskutoimitus suoritetaan normaalisti plussaamalla.
                        laskutoimitus = laskutoimitus + numero;
                    }
                }
                //Muuntaa lasketun summan string-muotoon.
                str = Convert.ToString(laskutoimitus);
                kerrointarkistus++;
            }
            //Palauttaa summan.
            return str;
        }
        static int Tarkistenumero(string numerosarja)
        {
            //Luhnin algoritmin mukaisesti ottaa talteen numerosarjan viimeisen luvun, eli tarkistusluvun/tarkistenumeron.
            int tarkistenumero = 0;
            tarkistenumero = int.Parse($"{numerosarja[numerosarja.Length - 1]}");
            return tarkistenumero;
        }
        static int LuhnTarkistus(string summa)
        {
            int tn;
            int tarkistenumero;
            tarkistenumero = int.Parse(summa) % 10;
            if (tarkistenumero > 0)
            {
                tn = 10 - tarkistenumero;
            }
            else
            {
                tn = tarkistenumero;
            }
            return tn;
        }
    }
}
