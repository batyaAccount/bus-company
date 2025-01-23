using System.ComponentModel.DataAnnotations;

namespace busCompany.API.PostEntity
{
    public class EmployeePostEntity
    {

      
        public string Name { get; set; }
        public string Tz { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int WorkType { get; set; }
        public int AmountOfHours { get; set; }
        public int Salary { get; set; }
        public DateTime StartDate { get; set; }


    }
}
