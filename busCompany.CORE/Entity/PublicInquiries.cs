using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.Core.Entity
{
    public class PublicInquiries
    {
        public int Id { get; set; }
        public int Driver { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int CaredBy { get; set; }
        public bool Cared { get; set; }
        public string ComplainerName { get; set; }
        public string PhoneNumber { get; set; }

        public PublicInquiries(int id, int driver, DateTime date, string description, int caredBy, bool cared, string complainerName, string phoneNumber)
        {
            Id = id;
            Driver = driver;
            Date = date;
            Description = description;
            CaredBy = caredBy;
            Cared = cared;
            ComplainerName = complainerName;
            PhoneNumber = phoneNumber;
        }

        public PublicInquiries()
        {
        }
    }
}
