using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teht3ECsharp
{
    public class Employee
    {
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Department Department { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        
        public string Name
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        
        public int Age
        {
            get
            {
                if (DateOfBirth == null)
                {
                    return 0;
                }
                else
                {
                    return DateTime.Now.Year - DateOfBirth.Value.Year;
                }
            }
        }
        private double _salary;
        public double Salary
        {
            get
            {
                return Math.Round(_salary, 2);
            }
            set
            {
                if (_salary < 0)
                {
                    throw new Exception("Negatiivinen palkka");
                }
                _salary = value;
            }
        }

        public Employee(int id, string first, string last, DateTime dob, double salary)
        {
            Id = id;
            FirstName = first;
            LastName = last;
            DateOfBirth = dob;
            Salary = salary;

            StartDate = DateTime.Now;
            EndDate = null;           
        }
        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName}";
        }
    }
}
