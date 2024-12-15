using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.Core.Entity
{
    public enum typeOfStstion { urban = 1, interstate = 2 }

    public class Station
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int StationNumber { get; set; }
        public string? GpsWaypoint { get; set; }
        public int Type { get; set; }

    }

}
