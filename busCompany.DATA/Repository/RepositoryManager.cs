using busCompany.Core.Entity;
using busCompany.Core.IRepository;
using busCompany.CORE.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.DATA.Repository
{
    public class RepositoryManager : IRepositoryMamager
    {
        private readonly DataContext _context;
        public IRepository<Bus> Buses { get; }
        public IRepository<Employee> Employees { get; }
        public IRepository<PublicInquiries> PublicInquiries { get; }
        public IRepository<Route> Routes { get; }
        public IRepository<Station> Stations { get; }
        public RepositoryManager(DataContext context, IRepository<Bus> BusesRepository, IRepository<Employee> EmployeesRepository, IRepository<PublicInquiries> PublicInquiriesRepository, IRepository<Route> RoutesRepository, IRepository<Station> StationsRepository)
        {
            _context = context;
            Buses = BusesRepository;
            Stations = StationsRepository;
            PublicInquiries = PublicInquiriesRepository;
            Employees = EmployeesRepository;
            Routes = RoutesRepository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
