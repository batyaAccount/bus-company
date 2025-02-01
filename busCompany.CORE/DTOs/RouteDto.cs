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
    public class RouteDto
    {
        public int Id { get; set; }
        public int BusLineId { get; set; }
        public int DriverId { get; set; }
        public int StationId { get; set; }
        public int SourceStationId { get; set; }
        public DateTime HourOfFirstBus { get; set; }
        public DateTime HourOfLastBus { get; set; }
    }
}
