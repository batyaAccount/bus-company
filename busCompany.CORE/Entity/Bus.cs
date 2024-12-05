using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.Core.Entity
{
    public enum typeBus { electric, byGaz }

    public class Bus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BusLine { get; set; }
        public string SourceStation { get; set; }
        public string DestinationStation { get; set; }
        public string Type { get; set; }
        public int TravelTime { get; set; }
        public bool IsActive { get; set; }

        public Bus(int id, int busLine, string sourceStation, string destinationStation, string type, int travelTime, bool isActive)
        {
            this.Id = id;
            this.BusLine = busLine;
            this.SourceStation = sourceStation;
            this.DestinationStation = destinationStation;
            this.Type = type;
            this.TravelTime = travelTime;
            this.IsActive = isActive;
        }
        public Bus()
        {

        }
    }
}
