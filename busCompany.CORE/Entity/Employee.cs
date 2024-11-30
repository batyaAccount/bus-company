using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.Core.Entity
{
    public enum workingType { driver, officeEmployee, cleaner }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tz { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string WorkType { get; set; }
        public int AmountOfHours { get; set; }
        public int Salary { get; set; }
        public DateTime StartDate { get; set; }

        public Employee(int id, string name, string tz, string address, string phoneNumber, string workerType, int amountOfHours, int salary, DateTime startDate)
        {
            this.Id = id;
            this.Name = name;
            this.Tz = tz;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.WorkType = workerType;
            this.AmountOfHours = amountOfHours;
            this.Salary = salary;
            this.StartDate = startDate;
        }
        public Employee()
        {
        }
    }
}
