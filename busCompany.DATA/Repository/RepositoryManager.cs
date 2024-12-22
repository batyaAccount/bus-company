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
        public IBusesRepository Buses { get; }
        public IEmployeeRepository Employees { get; }
        public IPublicInquiriesRepository PublicInquiries { get; }
        public IRouteRepository Routes { get; }
        public IStationRepository Stations { get; }
        public RepositoryManager(DataContext context, IBusesRepository BusesRepository, IEmployeeRepository EmployeesRepository, IPublicInquiriesRepository PublicInquiriesRepository, IRouteRepository RoutesRepository, IStationRepository StationsRepository)
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
