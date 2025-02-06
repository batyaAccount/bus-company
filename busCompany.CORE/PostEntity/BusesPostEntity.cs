using busCompany.Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace busCompany.API.PostEntity
{
    public class BusesPostEntity
    {
        public int BusLine { get; set; }
        public int SourceStationId { get; set; }
        public int DestinationStationId { get; set; }
        public int Type { get; set; }
        public int TravelTime { get; set; }
        public bool? IsActive { get; set; }

    }
}
