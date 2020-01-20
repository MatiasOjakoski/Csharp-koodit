using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Teht4ECsharp
{
    public static class Application
    {
        public static int LastOperationId = 0;
        public static List<Operation> Operations = new List<Operation>();
        public static Random r = new Random();
        public static int MaxBreaks = 10;
        public static int MinTimeInSeconds = 5;
        public static int MaxTimeInSeconds = 10;

        public static void PrintOperations(List<Operation>Operations)
        {
            Operations.ForEach(Operation => Operation.PrintEnded());
        }
        //Alla oleva koodi mahdollisesti väärin.
        public static async Task KaynnistaOperaatioAsync(Operation Operaatio)
        {
            await Task.Run(() => {
                Thread.Sleep(Operation.TotalTimeInSeconds * Convert.ToInt32(1.0) / Operation.Breaks * 1000);
                Operation.SpendTimeInSeconds = (Operation.TotalTimeInSeconds * Convert.ToInt32(1.0) / Operation.Breaks);
                Operation.Print();
            } );

            Operation.Ended = DateTime.Now;
        }
        
        //Alla oleva koodi keskeneräistä ja mahdollisesti väärin.
        public static void Run()
        {
            //string.Concat(Enumerable.Repeat(" ", 60));  
            Console.WriteLine("Käynnistä uusi operaatio = K, Lopeta ohjelma = L:");
            string syote = Console.ReadLine();
            if(syote == "l")
            {
                //string.Concat(Enumerable.Repeat(" ", 60));
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Paina Enter, kun kaikki operaatiot on suoritettu");
                    PrintOperations(Operations);
                Console.ReadKey();
            }
            if(syote == "k")
            {
                LastOperationId++;
                //new Operation {Operation.Id = LastOperationId, Operation.Breaks = r.Next(1 - MaxBreaks), Operation.TotalTimeInSeconds = r.Next(MinTimeInSeconds, MaxTimeInSeconds)}
                //KaynnistaOperaatioAsync();
            }
        }
    }
}
