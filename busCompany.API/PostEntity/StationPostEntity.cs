using System.ComponentModel.DataAnnotations;

namespace busCompany.API.PostEntity
{
    public class StationPostEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int StationNumber { get; set; }
        public string GpsWaypoint { get; set; }
        public int Type { get; set; }
    }
}
