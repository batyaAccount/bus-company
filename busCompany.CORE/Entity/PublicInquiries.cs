using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.Core.Entity
{
    public class PublicInquiries
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Driver { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public int CaredBy { get; set; }
        public bool Cared { get; set; }
        [MaxLength(50)]
        [Required]
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
