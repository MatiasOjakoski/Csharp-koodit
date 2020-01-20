using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teht2ECsharp
{
    static class Application
    {
        private static ConsoleControl JobEmployees;
        private static ConsoleControl JobDetails;
        private static ConsoleControl JobMenu;
        private static void BindMenuData(List<Job> e)
        {
            //Tässä listataan työn Id ja nimi sekä annetaan tekstille punainen väri ja taustalle harmaa väri.
            foreach (Job d in e)
            {
                (JobMenu.Items ?? (JobMenu.Items = new List<string>())).Add($"{d.Id} {d.Title}");
            }

            JobMenu.TextColor = ConsoleColor.DarkRed;
            JobMenu.BackColor = ConsoleColor.Gray;
        }
        private static void BindDetailsData(Job e)
        {
            //Tässä annetaan työn tiedot sekä annetaan tekstille sininen väri ja taustalle harmaa väri.
            if (JobDetails.Items == null)
            {
                JobDetails.Items = new List<string>();
            }
            else
            {
                JobDetails.Items.Clear();
            }

            JobDetails.Items.Add("TYÖN TIEDOT");
            JobDetails.Items.Add($"Id: {e.Id}");            JobDetails.Items.Add($"Nimi: {e.Title}");            JobDetails.Items.Add($"Alkaa: {e.StartDate.ToShortDateString()}");            JobDetails.Items.Add($"Loppuu: {e.EndDate.ToShortDateString()}");

            JobDetails.TextColor = ConsoleColor.Blue;            JobDetails.BackColor = ConsoleColor.Gray;
        }
        private static void BindEmployeesData(Job e)
        {
            if (JobEmployees.Items == null)
            {
                JobEmployees.Items = new List<string>();
            }
            else
            {
                JobEmployees.Clear();
            }
            foreach (Employee d in Data.employees)
            {
                foreach (Job g in d.Jobs)
                    if (g.Id == e.Id)
                    {
                        JobEmployees.Items.Add(d.Name);
                    }

                JobEmployees.TextColor = ConsoleColor.DarkRed;
                JobEmployees.BackColor = ConsoleColor.Gray;
            }
        }
        private static void Initialize()
        {
            //Annetaan "ikkunoiden" kokoon liittyvät asetukset.
            JobMenu = new ConsoleControl(1, 2, Data.jobs.Count, Convert.ToInt32(Console.WindowWidth * 0.5 - 1));

            JobDetails = new ConsoleControl(Convert.ToInt32(Console.WindowWidth/2 + 1),
            2, 5, Convert.ToInt32(Console.WindowWidth * 0.5) - 1);

            JobEmployees = new ConsoleControl(Convert.ToInt32(Console.WindowWidth/2 + 1),
            JobDetails.Height + 3, 5, Convert.ToInt32(Console.WindowWidth * 0.5) - 1);

            BindMenuData(Data.jobs);

            Mediator.Instance.JobChanged += new System.EventHandler<JobChangedEventArgs>(Tapahtuma);
        }
        private static void MenuSelectionChanged(int id)
        {
            foreach (Job e in Data.jobs)
            {
                if (e.Id == id)
                {
                    Mediator.Instance.OnJobChanged(JobMenu, e);
                }
                JobDetails.Draw();
                JobEmployees.Draw();
            }
        }
        public static void Run()
        {
            Initialize();
            JobMenu.Draw();

            do
            {
                Console.SetCursorPosition(0, 0);
                Console.Write("Valitse työn Id (Nolla lopettaa): ");  
                
                string syote = Console.ReadLine();
                int value;
                if (int.TryParse(syote, out value))
                {
                    if (value == 0)
                    {
                        break;
                    }
                    if (value >= 0 && value <= JobMenu.Items.Count)
                    {
                        MenuSelectionChanged(value);
                    }
                    else
                    {
                        {
                            Console.SetCursorPosition(0, 0);
                            Console.Write("Virheellinen syöte. Paina Enter. ");
                            Console.ReadKey();

                            ClearCurrentConsoleLine();
                        }
                    }
                }
                else
                {
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.Write("Virheellinen syöte. Paina Enter. ");
                        Console.ReadKey();

                        ClearCurrentConsoleLine();
                    }
                }
            } while (true);
        }
        private static void Tapahtuma(object sender, JobChangedEventArgs e)
        {
            BindEmployeesData(e.Job);
            BindDetailsData(e.Job);
        }
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;

            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
