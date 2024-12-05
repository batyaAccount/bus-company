using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int Driver { get; set; }
        public int Station { get; set; }
        public int SourceStationId { get; set; }
        public DateTime HourOfFirstBus { get; set; }
        public DateTime HourOfLastBus { get; set; }
        public Route()
        {
        }
        public Route(int id, int busLineId, int driver, int station, int sourceStationId, DateTime hourOfFirstBus, DateTime hourOfLastBus)
        {
            Id = id;
            BusLineId = busLineId;
            Driver = driver;
            Station = station;
            SourceStationId = sourceStationId;
            HourOfFirstBus = hourOfFirstBus;
            HourOfLastBus = hourOfLastBus;
        }
    }
}
