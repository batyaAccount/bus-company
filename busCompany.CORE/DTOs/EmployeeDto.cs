using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.CORE.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Tz { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public int WorkType { get; set; }
        public int AmountOfHours { get; set; }
        public int Salary { get; set; }
        public DateTime StartDate { get; set; }

    }
}
