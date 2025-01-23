using busCompany.Core.Entity;
using busCompany.Core.IRepository;
using busCompany.CORE.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.CORE.IRepository
{
    public interface IRepositoryMamager
    {

        IRepository<Bus> Buses { get; }
        IRepository<Employee> Employees { get; }
        IRepository<PublicInquiries> PublicInquiries { get; }
        IRepository<Route> Routes { get; }
        IRepository<Station> Stations { get; }

        void Save();

    }
}
