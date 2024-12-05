using busCompany.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using static System.Collections.Specialized.BitVector32;

namespace busCompany.DATA
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Employee> Employees { get; set; } 
        public DbSet<PublicInquiries> PublicInquiries { get; set; } 
        public DbSet<Station> Stations { get; set; } 
        public DbSet<Route> Routes { get; set; }

       

    }
}
