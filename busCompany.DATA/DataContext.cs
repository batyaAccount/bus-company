using busCompany.Core.Entity;
using busCompany.Data.Data;
using System.Text.Json;
using static System.Collections.Specialized.BitVector32;

namespace busCompany.DATA
{
    public class DataContext
    {

        public List<Bus> Buses { get; set; } = new List<Bus>();
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<PublicInquiries> PublicInquiries { get; set; } = new List<PublicInquiries>();
        public List<Station> Stations { get; set; } = new List<Station>();
        public List<Route> Routes { get; set; } = new List<Route>();

        public DataContext()
        {

            string path = Path.Combine(AppContext.BaseDirectory, "Data", "data.json");

            string jsonString = File.ReadAllText(path);
            DataLists emp = JsonSerializer.Deserialize<DataLists>(jsonString);
            if (emp != null)
            {
                Buses = emp.Buses;
                Employees = emp.Employees;
                PublicInquiries = emp.PublicInquiries;
                Stations = emp.Stations;
                Routes = emp.Routes;
            }
        }
        public void SaveChanges()
        {
            DataLists dataLists = new DataLists();
            dataLists.Buses = Buses;
            dataLists.Employees = Employees;
            dataLists.Routes = Routes;
            dataLists.Stations = Stations;
            dataLists.PublicInquiries = PublicInquiries;
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "EmployeeData.json");

            string jsonString = JsonSerializer.Serialize<DataLists>(dataLists);

            File.WriteAllText(path, jsonString);

        }
    }
}
