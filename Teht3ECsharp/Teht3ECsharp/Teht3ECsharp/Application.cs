using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Teht3ECsharp
{
    public static class Application
    {
        static List<MenuItem> Menu;
        public static void WriteResult<T>(int itemid, List<T> result)
        {
            string row;
            //otsikkorivit
            WriteLine();
            WriteLine(Menu.Where(mi => mi.Id == itemid).First().Name.ToUpper());
            WriteLine("‐".PadRight(18 * result[0].GetType().GetProperties().Length + 2, '‐'));
            //sarakeotsikkorivit
            if (result.Count > 0)
            {
                row = "";
                foreach (PropertyInfo property in result[0].GetType().GetProperties())
                {
                    row += $"{property.Name}".PadRight(16) + " | ";
                }
                WriteLine(row);
            }
            WriteLine("‐".PadRight(18 * result[0].GetType().GetProperties().Length + 2, '‐'));
            //datarivit
            foreach (object item in result)
            {
                row = "";
                foreach (PropertyInfo property in item.GetType().GetProperties())
                {
                    row += $"{property.GetValue(item, null).ToString()}".PadRight(16) + " | ";
                }
                WriteLine(row);
            }
            WriteLine("‐".PadRight(18 * result[0].GetType().GetProperties().Length + 2, '‐'));
            WriteLine();
            Write("Paina Enter jatkaaksesi.");
            ReadLine();
        }
        static void InitializeMenu()
        {
            Menu = new List<MenuItem>();

            Menu.Add(new MenuItem() { Id = 1, Name = "50-vuotiaat työntekijät" });
            Menu.Add(new MenuItem() { Id = 2, Name = "Osastot yli 50 henkilöä" });
            Menu.Add(new MenuItem() { Id = 3, Name = "Sukuniemn työntekijät" });
            Menu.Add(new MenuItem() { Id = 4, Name = "Osastojen isoimmat palkat" });
            Menu.Add(new MenuItem() { Id = 5, Name = "Viisi yleisintä sukunimeä" });
            Menu.Add(new MenuItem() { Id = 6, Name = "Osastojen ikäjakaumat" });

            Menu[0].ItemSelected += (obj, a) =>
            {
                var result = from Employee e in Data.Employees
                             where e.Age == 50
                             select new { Nimi = e.Name, Ikä = e.Age, Osasto = e.Department.Name };

                WriteResult(a.ItemId, result.ToList());

                //Haetaan kaikki Employee-oliot joiden ikä on 50 ja listataan ne.

            };

            Menu[1].ItemSelected += (obj, a) =>
            {
                var muuttuja2 = from Department f in Data.Departments
                             where f.EmployeeCount > 50
                             orderby f.EmployeeCount descending
                             select new { Id = f.Id, Nimi = f.Name, Vahvuus = f.EmployeeCount };

                WriteResult(a.ItemId, muuttuja2.ToList());

                //Haetaan kaikki Department-Oliot joiden työntekijämäärä on yli 50 ja järjestetään ne tehtävänannon mukaan.

            };

            Menu[2].ItemSelected += (obj, a) =>
            {
                WriteLine("Anna työntekijän sukunimi:");
                string sunimi = ReadLine();
                var muuttuja3 = from Employee e in Data.Employees
                             where e.LastName == sunimi
                             select new { Id = e.Id, Nimi = e.Name };

                WriteResult(a.ItemId, muuttuja3.ToList());

                //Pyydetään käyttäjältä työntekijän sukunimeä ja annetaan lista annetun sukunimen omaavista työntekijöistä.

            };

            Menu[3].ItemSelected += (obj, a) =>
            {
                var muuttuja4 = Data.Departments.SelectMany(d => d.Employees,
                (d, e) => new { Osasto = d.Name, Palkka = e.Salary })
                .GroupBy(os => os.Osasto)
                .Select(ryhma => new { Osasto = ryhma.Key, MaksimiPalkka = ryhma.Max(os => os.Palkka) });

                WriteResult(a.ItemId, muuttuja4.ToList());

                //Haetaan osastojen suurimmat palkat.

            };

            Menu[4].ItemSelected += (obj, a) =>
            {
                var sukunimet = from p in Data.Employees
                                group p by p.LastName into g
                                select new { Sukunimi = g.Key, Lkm = g.Count() };

                var laskevasnimi = sukunimet.OrderByDescending(p => p.Lkm).Take(5);

                WriteResult(a.ItemId, laskevasnimi.ToList());

                //Haetaan viisi yleisintä sukunimeä.

            };

            Menu[5].ItemSelected += (obj, a) =>
            {
                var muuttuja6 = Data.Departments.SelectMany(d => d.Employees,
                    (d, e) => new { Osasto = d.Name, Ikä = e.Age })
                    .GroupBy(os => os.Osasto)
                    .Select(ryhma => new
                    {
                        Nimi = ryhma.Key,
                        Alle30v = ryhma.Where(os => os.Ikä < 30).Count(),
                        Välillä30_50 = ryhma.Where(os => os.Ikä >= 30 && os.Ikä <= 50).Count(),
                        Yli50v = ryhma.Where(os => os.Ikä > 50).Count()
                    });

                WriteResult(a.ItemId, muuttuja6.ToList());

                //Listataan osastojen ikajakaumat: Alle 30v, 30-50v ja yli 50v.

            };
        }
        public static void Initialize()
        {
            Data.GenerateData();
            InitializeMenu();
        }
        public static int ReadfromMenu()
        {

            //Ohjelman valikko, joka pyytää käyttäjältä syötettä 0-6. 

            System.Console.Clear();
            WriteLine("Vaihtoehdot ");
            foreach (MenuItem e in Menu)
            {
                WriteLine($"{e.Id}. {e.Name}");
            }

            Write("Valitse (0 = Lopetus): ");
            string syote = ReadLine();
            int numero;
            if (int.TryParse(syote, out numero))
            {
                if (syote.Length != 0 && Convert.ToInt32(syote) >= 0 && Convert.ToInt32(syote) <= 6)
                {
                    return (Convert.ToInt32(syote));
                }
                else { throw new Exception("Vastaus ei ole kelvollinen"); }
            }
            else { throw new Exception("Vastaus ei ole kelvollinen"); }
        }

        public static void Run()
        {
            Initialize();
            do
            {
                int syote = ReadfromMenu();

                if (syote == 0)
                {
                    break;
                }
                foreach (MenuItem e in Menu)
                {
                    if (e.Id == syote)
                    {
                        e.Select();
                    }
                }
            } while (true);
        }
    }
}
