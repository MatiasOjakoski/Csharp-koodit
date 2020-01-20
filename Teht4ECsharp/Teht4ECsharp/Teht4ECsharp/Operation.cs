using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teht4ECsharp
{
    public class Operation
    { 
        public static int Id { get; set; }
        public static int TotalTimeInSeconds { get; set; }
        public static int SpendTimeInSeconds { get; set; }
        public static int Breaks { get; set; }
        public static DateTime Started { get; set; }
        public static DateTime Ended { get; set; }

        public Operation()
        {
            Started = DateTime.Now;
        }

        public static void Print()
        {
            Console.SetCursorPosition(0, Id);
            Console.WriteLine($"{Id} {Convert.ToDateTime(Started.ToLongTimeString())}" +
                $" {Math.Round((double)Convert.ToInt32(SpendTimeInSeconds / TotalTimeInSeconds * 100),2)}");

            Console.SetCursorPosition(0, 0);
        }       
        public static void PrintEnded()
        {
            Console.SetCursorPosition(0, Id);
            Console.WriteLine($"{Id} {Convert.ToDateTime(Started.ToLongTimeString())} -" +
                $" {Convert.ToDateTime(Ended.ToLongTimeString())} = {Ended - Started}");

            Console.SetCursorPosition(0, 0);
        }
    }
}
