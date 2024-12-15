using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.Core.Entity
{
    public enum typeBus { electric = 1, byGaz = 2}

    public class Bus
    {
        [Key]
        public int BusId { get; set; }
        [Required]
        public int BusLine { get; set; }
        public int SourceStationId { get; set; }
        [ForeignKey(nameof(SourceStationId))]
        public Station SourceStation { get; set; }
        public int DestinationStationId { get; set; }
        [ForeignKey(nameof(DestinationStationId))]
        public Station DestinationStation { get; set; }
        public int Type { get; set; }
        public int TravelTime { get; set; }
        public bool? IsActive { get; set; }

    }
}
