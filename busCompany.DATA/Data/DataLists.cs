using busCompany.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.Data.Data
{
    public class DataLists
    {
        public List<Bus> Buses { get; set; } = new List<Bus>();
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<PublicInquiries> PublicInquiries { get; set; } = new List<PublicInquiries>();
        public List<Station> Stations { get; set; } = new List<Station>();
        public List<Route> Routes { get; set; } = new List<Route>();

    }
}
