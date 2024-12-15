using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.Core.Entity
{
    public class Route
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BusLineId { get; set; }
        [Required]
        public int DriverId { get; set; }
        [ForeignKey(nameof(DriverId))]
        public Employee Driver { get; set; }
        public int StationId { get; set; }
        [ForeignKey(nameof(StationId))]
        public Station Station { get; set; }
        public int SourceStationId { get; set; }
        public DateTime HourOfFirstBus { get; set; }
        public DateTime HourOfLastBus { get; set; }
     
    }
}
