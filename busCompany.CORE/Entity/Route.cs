using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.Core.Entity
{
    public class Route
    {
        public int Id { get; set; }
        public int BusLineId { get; set; }
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
