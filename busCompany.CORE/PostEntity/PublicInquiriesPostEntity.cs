using busCompany.Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace busCompany.API.PostEntity
{
    public class PublicInquiriesPostEntity
    {
        public int DriverId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int CaredBy { get; set; }
        public bool Cared { get; set; }
        public string ComplainerName { get; set; }
        public string PhoneNumber { get; set; }

    }
}
