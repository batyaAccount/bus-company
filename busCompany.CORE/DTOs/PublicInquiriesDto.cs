using busCompany.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.CORE.DTOs
{
    public class PublicInquiriesDto
    {

        public int Id { get; set; }
        public int DriverId { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }

        public int CaredBy { get; set; }
        public bool? Cared { get; set; }
        public string ComplainerName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
