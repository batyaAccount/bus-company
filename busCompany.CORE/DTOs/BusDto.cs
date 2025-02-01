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
    public class BusDto
    {
        public int BusId { get; set; }
        public int BusLine { get; set; }
        public int SourceStationId { get; set; }
        public int DestinationStationId { get; set; }
        public int Type { get; set; }
        public int TravelTime { get; set; }
        public bool? IsActive { get; set; }
    }
}
