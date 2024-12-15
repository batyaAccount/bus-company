using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int DriverId { get; set; }
        [ForeignKey(nameof(DriverId))]
        public Employee Driver { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(1000)]
        public string? Description { get; set; }
        public int CaredBy { get; set; }
        public bool? Cared { get; set; }
        [MaxLength(50)]
        [Required]
        public string ComplainerName { get; set; }
        public string? PhoneNumber { get; set; }

     
    }
}
