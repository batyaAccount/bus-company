using busCompany.Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace busCompany.API.PostEntity
{
    public class RoutePostEntity
    {
        
        public int BusLineId { get; set; }
        public int DriverId { get; set; }
        public int StationId { get; set; }
        public int SourceStationId { get; set; }
        public DateTime HourOfFirstBus { get; set; }
        public DateTime HourOfLastBus { get; set; }

    }
}
