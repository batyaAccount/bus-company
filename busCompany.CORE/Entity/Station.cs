using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.Core.Entity
{
    public enum typeOfStstion { urban, interstate }

    public class Station
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int StationNumber { get; set; }
        public string GpsWaypoint { get; set; }
        public string Type { get; set; }

        public Station(int id, string name, string city, string street, int stationNumber, string gpsWaypoint, string type)
        {
            Id = id;
            Name = name;
            City = city;
            Street = street;
            StationNumber = stationNumber;
            GpsWaypoint = gpsWaypoint;
            this.Type = type;
        }

        public Station()
        {
        }
    }
}
